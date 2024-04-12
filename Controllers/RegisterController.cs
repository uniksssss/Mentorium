using System.Text.Json.Nodes;
using Mentorium.Models;
using Mentorium.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class RegisterController : ControllerBase
{
    private IUserRepository _userRepository;

    public RegisterController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [Authorize]
    [HttpGet("/register")]
    public async Task<IActionResult> RegisterPage()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/register.html");
        return File(html, "text/html");
    }
    
    [Authorize]
    [HttpPost("/api/users/register")]
    public async Task Register([FromBody] JsonObject json)
    {
        var githubId = int.Parse(HttpContext.User.Claims
            .First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            .Value);

        var user = new User
        {
            FirstName = json["first_name"]!.GetValue<string>(),
            LastName = json["last_name"]!.GetValue<string>()
        };

        await _userRepository.AddUserAsync(user, githubId);
    }
}