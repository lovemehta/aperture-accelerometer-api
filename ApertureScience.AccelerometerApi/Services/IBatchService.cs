using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines the functionality for processing batches of acceleration measurements.
    /// </summary>
    public interface IBatchService
    {
        /// <summary>
        /// Processes a collection of acceleration measurements asynchronously by batching them.
        /// </summary>
        /// <param name="userId">The ID of the user associated with the measurements.</param>
        /// <param name="measurements">The collection of acceleration measurement requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ProcessMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements);
    }
}
