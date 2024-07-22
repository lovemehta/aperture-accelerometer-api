using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Repositories;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for managing test subjects in the application.
    /// </summary>
    public class TestSubjectService : ITestSubjectService
    {
        private readonly ITestSubjectRepository _testSubjectRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSubjectService"/> class.
        /// </summary>
        /// <param name="testSubjectRepository">The test subject repository.</param>
        public TestSubjectService(ITestSubjectRepository testSubjectRepository)
        {
            _testSubjectRepository = testSubjectRepository;
        }

        /// <summary>
        /// Asynchronously retrieves all test subjects' email addresses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of test subjects' email addresses.</returns>
        public async Task<IEnumerable<string>> GetAllTestSubjectsAsync()
        {
            return await _testSubjectRepository.GetAllTestSubjectsAsync();
        }
    }
}
