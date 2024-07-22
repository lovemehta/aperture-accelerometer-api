using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApertureScience.AccelerometerApi.Services;

namespace ApertureScience.AccelerometerApi.Controllers
{
    /// <summary>
    /// API Controller for managing test subjects.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestSubjectController : ControllerBase
    {
        private readonly ITestSubjectService _testSubjectService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSubjectController"/> class.
        /// </summary>
        /// <param name="testSubjectService">The test subject service.</param>
        public TestSubjectController(ITestSubjectService testSubjectService)
        {
            _testSubjectService = testSubjectService;
        }

        /// <summary>
        /// Retrieves the list of all test subjects' email addresses.
        /// </summary>
        /// <returns>An IActionResult containing the list of test subjects' email addresses.</returns>
        [HttpGet("list")]
        public async Task<IActionResult> ListTestSubjects()
        {
            var testSubjects = await _testSubjectService.GetAllTestSubjectsAsync();
            return Ok(testSubjects);
        }
    }
}
