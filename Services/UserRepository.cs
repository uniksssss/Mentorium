using Mentorium.Migrations;
using Mentorium.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorium.Services;

public class UserRepository : IUserRepository
{
    private MentoriumDbContext _dbContext;

    public UserRepository(MentoriumDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetUserByUserIdAsync(int userId)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(e => e != null && e.UserId == userId);
    }

    public async Task<User?> GetUserByGithubIdAsync(int githubId)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(e => e != null && e.GithubId == githubId);
    }

    public async Task<User?[]> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToArrayAsync();
    }

    public async Task<User?[]> GetAllMentorsAsync()
    {
        return await _dbContext.Users.Include(u => u.Skills)
            .Where(e => e.IsMentor)
            .ToArrayAsync();
    }

    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        return Task.CompletedTask;
    }

    public async Task<Skill?[]> GetAllSkillsAsync()
    {
        return await _dbContext.Skills.ToArrayAsync();
    }

    public async Task<Skill?[]> GetSkillsByIdAsync(ICollection<int> skillsId)
    {
        var set = new HashSet<int>(skillsId);
        return await _dbContext.Skills.Where(s => set.Contains(s.SkillId)).ToArrayAsync();
    }
}