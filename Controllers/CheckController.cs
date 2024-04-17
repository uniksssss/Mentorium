using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class CheckController : ControllerBase
{
    [Authorize]
    [HttpGet("/api/check")]
    public async Task<IActionResult> Check()
    {
        return Ok();
    }
}