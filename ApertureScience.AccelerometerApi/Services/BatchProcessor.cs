using System.Collections.Generic;
using System.Linq;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public class BatchProcessor : IBatchProcessor
    {
        public IEnumerable<IEnumerable<AccelerationMeasurement>> CreateBatches(IEnumerable<AccelerationMeasurement> measurements, int batchSize)
        {
            return measurements
                .Select((measurement, index) => new { measurement, index })
                .GroupBy(x => x.index / batchSize)
                .Select(g => g.Select(x => x.measurement));
        }
    }
}
