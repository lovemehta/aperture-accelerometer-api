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
        private readonly IBatchService _batchService;
        private readonly UserManager<IdentityUser> _userManager;

        public AccelerationController(IBatchService batchService, UserManager<IdentityUser> userManager)
        {
            _batchService = batchService;
            _userManager = userManager;
        }

        [HttpPost("ingest")]
        public async Task<IActionResult> IngestMeasurements([FromBody] IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Validate measurements
            if (measurements == null || !measurements.Any())
            {
                return BadRequest("Measurements cannot be null or empty.");
            }

            // Process measurements
            await _batchService.ProcessMeasurementsAsync(user.Id, measurements);
            return Ok();
        }
    }
}
