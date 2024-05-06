using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [Authorize]
    [HttpGet("/hello")]
    public async Task<IActionResult> GetHelloWorld()
    {
        return new JsonResult(HttpContext.User.Claims.ToDictionary(e => e.Type, e => e.Value));
    }

    [AllowAnonymous]
    [HttpGet("/")]
    public async Task<IActionResult> GetRoot()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/home.html");
        return File(html, "text/html");
    }

    [AllowAnonymous]
    [HttpGet("/mentors")]
    public async Task<IActionResult> GetMentors()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/mentors_list.html");
        return File(html, "text/html");
    }
    
    [AllowAnonymous]
    [HttpGet("/chat")]
    public async Task<IActionResult> GetChat()
    {
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/chat.html");
        return File(html, "text/html");
    }
}