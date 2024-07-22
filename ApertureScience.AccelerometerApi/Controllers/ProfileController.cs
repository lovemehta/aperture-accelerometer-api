using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Services;
using Microsoft.AspNetCore.Mvc;

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
