using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines the functionality for consuming and processing acceleration measurements asynchronously.
    /// </summary>
    public interface IAsyncConsumer
    {
        /// <summary>
        /// Consumes and processes a collection of acceleration measurements asynchronously.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurements.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ConsumeAsync(IEnumerable<AccelerationMeasurement> measurements);
    }
}
