using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IChatRepository _chatRepository;

        public ChatController(IUserRepository userRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }

        [Authorize]
        [HttpPost("/api/chats/new/{userId}")]
        public async Task<IActionResult> CreateNewChat(int userId)
        {
            var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value);

            var firstUser = await _userRepository.GetUserByUserIdAsync(githubId);
            var secondUser = await _userRepository.GetUserByUserIdAsync(userId);
            if (firstUser == null || secondUser == null)
            {
                return BadRequest();
            }
            var chat = new Chat();
            chat.Users.Add(firstUser);
            chat.Users.Add(secondUser);
            await _chatRepository.AddChatAsync(chat);
            return Ok();
        }

        [Authorize]
        [HttpGet("api/chats/all")]
        public async Task<IActionResult> AllChats()
        {
            return new JsonResult(await _chatRepository.GetAllChatsAsync());
        }

        [Authorize]
        [HttpGet("api/chats/getAllMessage/{chatId}")]
        public async Task<IActionResult> AllMessages(int chatId)
        {
            var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value);

            var chat = await _chatRepository.GetChatByChatIdAsync(chatId);
            if (!chat.Users.Any(c => c.UserId == githubId))
            {
                return Forbid();
            }
            return new JsonResult(await _chatRepository.GetAllMessageByChatIdAsync(chatId));
        }

        [Authorize]
        [HttpPost("api/chats/send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value);

            var chat = await _chatRepository.GetChatByChatIdAsync(dto.ChatId);

            if (githubId != dto.UserId || !chat.Users.Any(c => c.UserId == githubId))
            {
                return Forbid();
            }

            var message = new Message { ChatId = dto.ChatId, Text = dto.MessageText, UserId = githubId };
            await _chatRepository.SendMessageAsync(message);
            return Ok();
        }
    }
}
