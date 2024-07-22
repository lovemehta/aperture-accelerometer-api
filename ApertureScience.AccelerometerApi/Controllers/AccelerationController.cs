using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApertureScience.AccelerometerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _accelerationService;
        private readonly UserManager<IdentityUser> _userManager;

        public AccelerationController(IAccelerationService accelerationService, UserManager<IdentityUser> userManager)
        {
            _accelerationService = accelerationService;
            _userManager = userManager;
        }

        [HttpPost("ingest")]
        public async Task<IActionResult> IngestMeasurements([FromBody] IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("Came here");

                return Unauthorized();
            }

            // Validate measurements
            if (measurements == null || !measurements.Any())
            {
                return BadRequest("Measurements cannot be null or empty.");
            }

            // Ingest measurements
            await _accelerationService.IngestMeasurementsAsync(user.Id, measurements);
            return Ok();
        }
    }
}
