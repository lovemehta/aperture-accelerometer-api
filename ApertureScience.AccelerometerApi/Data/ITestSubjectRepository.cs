using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApertureScience.AccelerometerApi.Repositories
{
    /// <summary>
    /// Interface for TestSubject repository to manage TestSubject related data operations.
    /// </summary>
    public interface ITestSubjectRepository
    {
        /// <summary>
        /// Asynchronously retrieves all test subjects' email addresses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of test subjects' email addresses.</returns>
        Task<IEnumerable<string>> GetAllTestSubjectsAsync();
    }
}
