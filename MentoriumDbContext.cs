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

        public DbSet<User> Users { get; set; }
        public DbSet<TelegramUser> TelegramUsers { get; set; }
        public DbSet<GithubUser> GithubUsers { get; set; }
        public DbSet<MentorInfo> MentorInfo { get; set; }
        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<MentorInfoStack> MentorInfoStacks { get; set; }
        public DbSet<StudentInfoStack> StudentInfoStacksStack { get; set; }
        public DbSet<MentoriumStack> MentoriumStack { get; set; }
    }
}