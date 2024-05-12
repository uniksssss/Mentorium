using Mentorium.Constants;
using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mentorium.Dto;

namespace Mentorium.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IChatRepository _chatRepository;
        private ILogger<ChatController> _logger;

        public ChatController(
            IUserRepository userRepository,
            IChatRepository chatRepository,
            ILogger<ChatController> logger
        )
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("/api/chats/new/{userId}")]
        public async Task<ActionResult<ChatResponseDto>> CreateChat(int userId)
        {
            var githubId = int.Parse(HttpContext.User.Claims
                .First(e => e.Type == ClaimConstants.GithubIdClaimName)
                .Value);

            var firstUser = await _userRepository.GetUserByGithubIdAsync(githubId);
            var secondUser = await _userRepository.GetUserByUserIdAsync(userId);
            if (firstUser is null || secondUser is null)
            {
                return BadRequest();
            }
            var allChats = await _chatRepository.GetAllUserChatsAsync(firstUser.UserId);
            var existingChat = allChats.Where(c => c.Users.Any(u => u.UserId == secondUser.UserId)).FirstOrDefault();
            if (existingChat is not null)
            {
                return new ChatResponseDto(existingChat.ChatId);
            }

            var chat = new Chat { Users = { firstUser, secondUser } };
            await _chatRepository.AddChatAsync(chat);
            return new ChatResponseDto(chat.ChatId);
        }

        [Authorize]
        [HttpGet("api/chats/all")]
        public async Task<IActionResult> GetAllChats()
        {
            return new JsonResult(await _chatRepository.GetAllChatsAsync());
        }

        [Authorize]
        [HttpGet("api/chats/user/{userId}")]
        public async Task<IActionResult> GetAllUserChats(int userId)
        {
            return new JsonResult(await _chatRepository.GetAllUserChatsAsync(userId));
        }

        [Authorize]
        [HttpGet("api/chats/getAllMessage/{chatId}")]
        public async Task<IActionResult> GetAllMessagesByChatId([FromRoute] int chatId)
        {
            var githubId = int.Parse(HttpContext.User.Claims
                .First(e => e.Type == ClaimConstants.GithubIdClaimName)
                .Value);

            var user = await _userRepository.GetUserByGithubIdAsync(githubId);
            var chat = await _chatRepository.GetChatByChatIdAsync(chatId);
            if (chat.Users.All(c => c.UserId != user.UserId))
            {
                return Forbid();
            }

            return new JsonResult(await _chatRepository.GetAllMessageByChatIdAsync(chatId));
        }

        [Authorize]
        [HttpPost("api/chats/send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            var githubId = int.Parse(HttpContext.User.Claims
                .First(e => e.Type == ClaimConstants.GithubIdClaimName)
                .Value);

            var user = await _userRepository.GetUserByGithubIdAsync(githubId);
            var chat = await _chatRepository.GetChatByChatIdAsync(messageDto.ChatId);

            if (
                // user.UserId != messageDto.UserId || 
                chat.Users.All(c => c.UserId != user.UserId)
            )
            {
                return Forbid();
            }

            var message = new Message
                { ChatId = messageDto.ChatId, MessageText = messageDto.MessageText, UserId = githubId };
            await _chatRepository.SendMessageAsync(message);
            return Ok();
        }
    }
}