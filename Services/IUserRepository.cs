using Mentorium.Models;

namespace Mentorium.Services;

public interface IUserRepository
{
    public Task<User?> GetUserByUserIdAsync(int userId);
    public Task<User?> GetUserByGithubIdAsync(int githubId);
    public Task<User?[]> GetAllUsersAsync();
    public Task<User?[]> GetAllMentorsAsync();
    public Task AddUserAsync(User user);
    public Task UpdateUserAsync(User user);
}