using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines the functionality for managing user profiles.
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Creates a new user profile asynchronously.
        /// </summary>
        /// <param name="model">The profile model containing the user details.</param>
        /// <returns>A task representing the asynchronous operation, containing a <see cref="ValidationResult"/>.</returns>
        Task<ValidationResult> CreateProfileAsync(ProfileModel model);
    }
}
