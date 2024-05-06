using Mentorium.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorium.Services
{
    public class ChatRepository : IChatRepository
    {
        private MentoriumDbContext _context;

        public ChatRepository(MentoriumDbContext context)
        {
            _context = context;
        }

        public async Task AddChatAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(Message message)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task EditMessageAsync(Message message)
        {
            _context.Messages.Update(message);
        }

        public async Task<Chat?[]> GetAllChatsAsync()
        {
            return await _context.Chats.Include(c => c.Users).ToArrayAsync();
        }

        public async Task<Message?[]> GetAllMessageByChatIdAsync(int chatId)
        {
            return await _context.Messages.Where(m => m.ChatId == chatId).OrderBy(m => m.DateTime).ToArrayAsync();
        }

        public async Task<Chat?> GetChatByChatIdAsync(int chatId)
        {
            return await _context.Chats
                .Include(c => c.Users)
                .Where(c => c.ChatId == chatId)
                .SingleOrDefaultAsync();
        }

        public async Task RemoveChatAsync(Chat chat)
        {
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync(true);
        }
    }
}
