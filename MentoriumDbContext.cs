using Microsoft.EntityFrameworkCore;
using Mentorium.Models;
using Microsoft.AspNetCore.Identity;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var skillId = 1;
            modelBuilder.Entity<Skill>().HasData(new Skill { SkillId = skillId++, SkillName = "SEO" },
                new Skill { SkillId = skillId++, SkillName = "DataSciense" }, new Skill { SkillId = skillId++, SkillName = "Комп. Безопастность" },
                new Skill { SkillId = skillId++, SkillName = "Аналитика" }, new Skill { SkillId = skillId++, SkillName = "DevOps" },
                new Skill { SkillId = skillId++, SkillName = "Python" }, new Skill { SkillId = skillId++, SkillName = "QA" },
                new Skill { SkillId = skillId++, SkillName = "Web-design" }, new Skill { SkillId = skillId++, SkillName = "Вёрстка" },
                new Skill { SkillId = skillId++, SkillName = "SQL" });
        }

        public DbSet<User?> Users { get; set; }
        public DbSet<Chat?> Chats { get; set; }
        public DbSet<Message?> Messages { get; set; }
        public DbSet<Skill?> Skills { get; set; }
    }
}