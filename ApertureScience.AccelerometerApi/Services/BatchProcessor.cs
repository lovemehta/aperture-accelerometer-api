using System.Collections.Generic;
using System.Linq;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.Extensions.Configuration;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for processing batches of acceleration measurements.
    /// </summary>
    public class BatchProcessor : IBatchProcessor
    {
        private readonly int _batchSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchProcessor"/> class.
        /// </summary>
        /// <param name="configuration">The configuration settings.</param>
        public BatchProcessor(IConfiguration configuration)
        {
            _batchSize = configuration.GetValue<int>("BatchProcessing:BatchSize");
        }

        /// <summary>
        /// Creates batches from a collection of acceleration measurements.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurements.</param>
        /// <returns>An enumerable of batches, each containing a collection of acceleration measurements.</returns>
        public IEnumerable<IEnumerable<AccelerationMeasurement>> CreateBatches(IEnumerable<AccelerationMeasurement> measurements)
        {
            return measurements
                .Select((measurement, index) => new { measurement, index })
                .GroupBy(x => x.index / _batchSize)
                .Select(g => g.Select(x => x.measurement));
        }
    }
}
