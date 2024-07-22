using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApertureScience.AccelerometerApi.Controllers
{
    /// <summary>
    /// API Controller for handling acceleration measurement ingestion.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccelerationController : ControllerBase
    {
        private readonly IBatchService _batchService;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccelerationController"/> class.
        /// </summary>
        /// <param name="batchService">The batch processing service.</param>
        /// <param name="userManager">The user manager service.</param>
        public AccelerationController(IBatchService batchService, UserManager<IdentityUser> userManager)
        {
            _batchService = batchService;
            _userManager = userManager;
        }

        /// <summary>
        /// Ingests a collection of acceleration measurements.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurement requests.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
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
