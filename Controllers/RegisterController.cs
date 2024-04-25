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

    [AllowAnonymous]
    [HttpGet("/register")]
    public async Task<IActionResult> RegisterPage()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/register.html");
        return File(html, "text/html");
    }
}