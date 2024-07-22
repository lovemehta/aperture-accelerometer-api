using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IBatchService
    {
        Task ProcessMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements);
    }
}
