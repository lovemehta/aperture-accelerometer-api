using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApertureScience.AccelerometerApi.Services;

namespace ApertureScience.AccelerometerApi.Controllers
{
    /// <summary>
    /// API Controller for managing activation codes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class ActivationCodesController : ControllerBase
    {
        private readonly IActivationCodeService _activationCodeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivationCodesController"/> class.
        /// </summary>
        /// <param name="activationCodeService">The activation code service.</param>
        public ActivationCodesController(IActivationCodeService activationCodeService)
        {
            _activationCodeService = activationCodeService;
        }

        /// <summary>
        /// Creates a new activation code.
        /// </summary>
        /// <returns>An IActionResult containing the created activation code and its expiration date.</returns>
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var code = await _activationCodeService.CreateActivationCodeAsync();
            return Ok(new { code.Code, code.ExpiresAt });
        }
    }
}
