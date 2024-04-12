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

    public async Task<User> GetUserByGithubIdAsync(int githubId)
    {
        var githubUser = await _dbContext.GithubUsers
            .Include(githubUser => githubUser.User)
            .SingleOrDefaultAsync();

        return githubUser?.User;
    }

    public async Task AddUserAsync(User user, int githubId)
    {
        await _dbContext.Users.AddAsync(user);
        
        await _dbContext.GithubUsers.AddAsync(new GithubUser
        {
            GithubUserId = githubId,
            User = user
        });

        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateUserAsync(User user, int githubId)
    {
        throw new NotImplementedException();
    }
}