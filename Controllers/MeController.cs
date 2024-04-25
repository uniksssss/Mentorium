using Mentorium.Models;
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
    
    [AllowAnonymous]
    [HttpGet("/me")]
    public async Task<IActionResult> MePage()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/me.html");
        return File(html, "text/html");
    }
}