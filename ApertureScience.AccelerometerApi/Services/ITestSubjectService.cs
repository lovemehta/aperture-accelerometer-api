using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Interface for TestSubject service to manage TestSubject related operations.
    /// </summary>
    public interface ITestSubjectService
    {
        /// <summary>
        /// Asynchronously retrieves all test subjects' email addresses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of test subjects' email addresses.</returns>
        Task<IEnumerable<string>> GetAllTestSubjectsAsync();
    }
}
