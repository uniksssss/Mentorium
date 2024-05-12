using Mentorium.Models;

namespace Mentorium.Services
{
    public interface IChatRepository
    {
        public Task<Chat?> GetChatByChatIdAsync(int chatId);
        public Task<Chat?[]> GetAllChatsAsync();
        public Task<Chat?[]> GetAllUserChatsAsync(int userId);
        public Task<Message?[]> GetAllMessageByChatIdAsync(int chatId);
        public Task AddChatAsync(Chat chat);
        public Task RemoveChatAsync(Chat chat);
        public Task SendMessageAsync(Message message);
        public Task EditMessageAsync(Message message);
        public Task DeleteMessageAsync(Message message);
    }
}
