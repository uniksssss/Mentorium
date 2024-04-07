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
        var html = await System.IO.File.ReadAllBytesAsync("wwwroot/index.html");
        return File(html, "text/html");
    }
}