using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Services;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Controllers
{
    /// <summary>
    /// API Controller for authentication operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager service.</param>
        /// <param name="jwtTokenService">The JWT token service.</param>
        public AuthController(UserManager<IdentityUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Generates a JWT token for the user based on the provided login model.
        /// </summary>
        /// <param name="model">The login model containing the user's credentials.</param>
        /// <returns>An IActionResult containing the generated JWT token.</returns>
        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenService.GenerateToken(user, roles[0]); // Assuming a user has at least one role

            return Ok(new { token });
        }
    }
}
