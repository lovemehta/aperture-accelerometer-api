using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines methods for ingesting acceleration measurements.
    /// </summary>
    public interface IAccelerationService
    {
        /// <summary>
        /// Ingests a collection of acceleration measurements for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the measurements are being ingested.</param>
        /// <param name="measurements">A collection of acceleration measurement requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task IngestMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements);
    }
}
