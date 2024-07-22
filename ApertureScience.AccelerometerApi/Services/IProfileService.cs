using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IProfileService
    {
        Task<ValidationResult> CreateProfileAsync(ProfileModel model);
    }
}
