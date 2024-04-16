using Mentorium.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class MeController : ControllerBase
{
    private IUserRepository _userRepository;

    public MeController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [Authorize]
    [HttpGet("/me")]
    public async Task<IActionResult> MePage()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/me.html");
        return File(html, "text/html");
    }
    
    [Authorize]
    [HttpGet("/api/users/me")]
    public async Task<IActionResult> Me()
    {
        var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value);

        var user = await _userRepository.GetUserByGithubIdAsync(githubId);
        
        return new JsonResult(user);
    }
}