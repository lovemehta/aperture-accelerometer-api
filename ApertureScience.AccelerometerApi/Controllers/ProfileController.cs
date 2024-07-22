using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApertureScience.AccelerometerApi.Controllers
{
    /// <summary>
    /// API Controller for managing user profiles.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileController"/> class.
        /// </summary>
        /// <param name="profileService">The profile service.</param>
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Creates a new user profile.
        /// </summary>
        /// <param name="model">The profile model containing the user's information.</param>
        /// <returns>An IActionResult containing the result of the profile creation operation.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProfileModel model)
        {
            var result = await _profileService.CreateProfileAsync(model);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { token = result.Token });
        }
    }
}
