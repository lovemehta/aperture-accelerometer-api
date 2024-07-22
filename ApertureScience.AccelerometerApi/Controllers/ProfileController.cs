using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Services;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile([FromBody] ProfileModel model)
        {
            var result = await _profileService.CreateProfileAsync(model);
            if (result.Success)
            {
                return Ok(new { token = result.Token });
            }
            return BadRequest(result.Errors);
        }
    }
}
