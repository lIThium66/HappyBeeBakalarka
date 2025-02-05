using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;

namespace VersionOneWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logged out succesfully !" });
        }
    }
}
