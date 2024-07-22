using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IAsyncConsumer
    {
        Task ConsumeAsync(IEnumerable<AccelerationMeasurement> measurements);
    }
}
