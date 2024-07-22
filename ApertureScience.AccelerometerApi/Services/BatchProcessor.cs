using System.Collections.Generic;
using System.Linq;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for processing batches of acceleration measurements.
    /// </summary>
    public class BatchProcessor : IBatchProcessor
    {
        /// <summary>
        /// Creates batches from a collection of acceleration measurements.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurements.</param>
        /// <param name="batchSize">The desired size of each batch.</param>
        /// <returns>An enumerable of batches, each containing a collection of acceleration measurements.</returns>
        public IEnumerable<IEnumerable<AccelerationMeasurement>> CreateBatches(IEnumerable<AccelerationMeasurement> measurements, int batchSize)
        {
            return measurements
                .Select((measurement, index) => new { measurement, index })
                .GroupBy(x => x.index / batchSize)
                .Select(g => g.Select(x => x.measurement));
        }
    }
}
