using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Mentorium.Constants;
using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebSocketsSample.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class WebSocketController : ControllerBase
{
    private IUserRepository _userRepository;
    private IChatRepository _chatRepository;
    private ILogger<WebSocketController> _logger;
    private ConcurrentDictionary<int, WebSocket> _clients;
    private ConcurrentDictionary<int, User> _users;

    public WebSocketController(
        IUserRepository userRepository,
        IChatRepository chatRepository,
        ILogger<WebSocketController> logger
    )
    {
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _logger = logger;
        _clients = new ConcurrentDictionary<int, WebSocket>();
        _users = new ConcurrentDictionary<int, User>();
    }

    [Route("/ws")]
    public async Task Get([FromQuery] int chatId)
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == ClaimConstants.GithubIdClaimName)
            .Value);

        var user = await _userRepository.GetUserByGithubIdAsync(githubId);
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        _clients.TryAdd(user!.UserId, webSocket);
        _users.TryAdd(user.UserId, user);

        var chat = await _chatRepository.GetChatByChatIdAsync(chatId);
        await Chatting(webSocket, user, chat!);
    }

    private async Task Chatting(WebSocket webSocket, User user, Chat chat)
    {
        var messages = await _chatRepository.GetAllMessageByChatIdAsync(chat.ChatId);
        foreach (var message in messages)
        {
            _users.TryGetValue(message!.UserId, out var messageUser);
            var sendMessage = new SendMessage
            {
                ChatId = message!.ChatId,
                DateTime = message.DateTime,
                MessageId = message.MessageId,
                MessageText = message.MessageText,
                User = messageUser!
            };
            var json = JObject.FromObject(sendMessage);
            var messageBytes = Encoding.UTF8.GetBytes(json.ToString());
            
            await webSocket.SendAsync(messageBytes,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
        
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            var received = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
            var receivedJson = JObject.Parse(received);
            var receivedMessage = receivedJson.ToObject<ReceiveMessage>();
            var message = new Message
            {
                ChatId = receivedMessage!.ChatId,
                UserId = user.UserId,
                MessageText = receivedMessage!.MessageText
            };
            await _chatRepository.SendMessageAsync(message);
            
            _users.TryGetValue(message!.UserId, out var messageUser);
            var sendMessage = new SendMessage
            {
                ChatId = message!.ChatId,
                DateTime = message.DateTime,
                MessageId = message.MessageId,
                MessageText = message.MessageText,
                User = messageUser!
            };
            var json = JObject.FromObject(sendMessage);
            var messageBytes = Encoding.UTF8.GetBytes(json.ToString());

            foreach (var userId in chat.Users.Select(u => u.UserId))
            {
                if (!_clients.TryGetValue(userId, out var userWebSocket))
                    continue;
                
                await userWebSocket.SendAsync(
                    new ArraySegment<byte>(messageBytes, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);
            }

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }
}

public class ReceiveMessage
{
    public int ChatId { get; set; }
    public string MessageText { get; set; }
}

public class SendMessage
{
    public int MessageId { get; set; }
    public int ChatId { get; set; }
    public User User { get; set; }
    public DateTime DateTime { get; set; }
    public string MessageText { get; set; }
}