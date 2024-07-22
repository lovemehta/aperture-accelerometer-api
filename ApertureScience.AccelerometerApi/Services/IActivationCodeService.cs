using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IActivationCodeService
    {
        Task<ActivationCode> CreateActivationCodeAsync();
    }
}
