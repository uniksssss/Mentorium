using Mentorium.Constants;
using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [Authorize]
    [HttpPost("/api/users/register")]
    public async Task Register([FromBody] UserDto userDto)
    {
        var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == ClaimConstants.GithubIdClaimName)
            .Value);

        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Description = userDto.Description,
            GithubId = githubId,
            TelegramId = userDto.TelegramId,
            IsMentor = userDto.IsMentor
        };
        await _userRepository.AddUserAsync(user);
    }
    
    [Authorize]
    [HttpPost("/api/users/create")]
    public async Task Create([FromBody] UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Description = userDto.Description,
            TelegramId = userDto.TelegramId,
            IsMentor = userDto.IsMentor
        };
        await _userRepository.AddUserAsync(user);
    }
    
    [Authorize]
    [HttpGet("/api/users/me")]
    public async Task<IActionResult> Me()
    {
        var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == ClaimConstants.GithubIdClaimName)
            .Value);

        var user = await _userRepository.GetUserByGithubIdAsync(githubId);
        
        return new JsonResult(user);
    }

    [Authorize]
    [HttpGet("api/users/all")]
    public async Task<IActionResult> AllUsers()
    {
        return new JsonResult(await _userRepository.GetAllUsersAsync());
    }
    
    [Authorize]
    [HttpGet("api/users/all_mentors")]
    public async Task<IActionResult> AllMentors()
    {
        return new JsonResult(await _userRepository.GetAllMentorsAsync());
    }

    public record UserDto(string FirstName, string LastName, string? Description, string? TelegramId, bool IsMentor);
}