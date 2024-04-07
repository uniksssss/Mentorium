using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorium.Controllers;

[ApiController]
public class SignInController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("/signin")]
    public async Task<IActionResult> SignIn([FromQuery] string returnUrl)
    {
        return Challenge(new AuthenticationProperties {RedirectUri = returnUrl});
    }
}