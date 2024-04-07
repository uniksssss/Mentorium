using Mentorium.Models;

namespace Mentorium.Services
{
    public class Repo
    {
        private MentoriumDbContext _dbContext;

        public Repo(MentoriumDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}