using System.Collections.Generic;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines the functionality for creating batches of acceleration measurements.
    /// </summary>
    public interface IBatchProcessor
    {
        /// <summary>
        /// Creates batches from a collection of acceleration measurements.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurements.</param>
        /// <returns>An enumerable of batches, each containing a collection of acceleration measurements.</returns>
        IEnumerable<IEnumerable<AccelerationMeasurement>> CreateBatches(IEnumerable<AccelerationMeasurement> measurements);
    }
}
