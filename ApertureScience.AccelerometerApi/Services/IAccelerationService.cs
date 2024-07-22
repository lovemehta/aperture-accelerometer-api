using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IAccelerationService
    {
        Task IngestMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements);
    }
}
