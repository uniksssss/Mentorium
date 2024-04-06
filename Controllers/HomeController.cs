using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

public class HomeController : ControllerBase
{
    [Authorize]
    [HttpGet("/hello")]
    public async Task<IActionResult> GetHelloWorld()
    {
        return new JsonResult(HttpContext.User.Claims.ToDictionary(e => e.Type, e => e.Value));
    }
}