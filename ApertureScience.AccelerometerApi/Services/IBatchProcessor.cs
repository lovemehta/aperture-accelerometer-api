using System.Collections.Generic;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IBatchProcessor
    {
        IEnumerable<IEnumerable<AccelerationMeasurement>> CreateBatches(IEnumerable<AccelerationMeasurement> measurements, int batchSize);
    }
}
