using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApertureScience.AccelerometerApi.Services;

namespace ApertureScience.AccelerometerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class ActivationCodesController : ControllerBase
    {
        private readonly ActivationCodeService _activationCodeService;

        public ActivationCodesController(ActivationCodeService activationCodeService)
        {
            _activationCodeService = activationCodeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var code = await _activationCodeService.CreateActivationCodeAsync();
            return Ok(new { code.Code, code.ExpiresAt });
        }
    }
}
