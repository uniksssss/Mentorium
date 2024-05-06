using Microsoft.EntityFrameworkCore;
using Mentorium.Models;

namespace Mentorium
{
    public class MentoriumDbContext : DbContext
    {
        public MentoriumDbContext()
        { }

        public MentoriumDbContext(DbContextOptions<MentoriumDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { }

        public DbSet<User?> Users { get; set; }
        public DbSet<Chat?> Chats { get; set; }
        public DbSet<Message?> Messages { get; set; }
    }
}