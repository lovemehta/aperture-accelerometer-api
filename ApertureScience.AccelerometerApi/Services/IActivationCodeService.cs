using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Provides functionality for managing activation codes.
    /// </summary>
    public interface IActivationCodeService
    {
        /// <summary>
        /// Creates a new activation code.
        /// </summary>
        /// <returns>The created <see cref="ActivationCode"/>.</returns>
        Task<ActivationCode> CreateActivationCodeAsync();
    }
}
