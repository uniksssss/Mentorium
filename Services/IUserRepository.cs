using Mentorium.Models;

namespace Mentorium.Services;

public interface IUserRepository
{
    public Task<User> GetUserByGithubIdAsync(int githubId);
    public Task AddUserAsync(User user, int githubId);
    public Task UpdateUserAsync(User user, int githubId);
}