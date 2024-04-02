using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

public class HomeController : ControllerBase
{
    [HttpGet("/hello")]
    public async Task<IActionResult> GetHelloWorld()
    {
        return Ok("Hello, World!");
    }
}