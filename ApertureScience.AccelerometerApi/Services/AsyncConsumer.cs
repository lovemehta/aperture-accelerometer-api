using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Data;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for asynchronously consuming and processing acceleration measurements.
    /// </summary>
    public class AsyncConsumer : IAsyncConsumer
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncConsumer"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AsyncConsumer(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Consumes and processes a collection of acceleration measurements asynchronously.
        /// </summary>
        /// <param name="measurements">The collection of acceleration measurements.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ConsumeAsync(IEnumerable<AccelerationMeasurement> measurements)
        {
            _context.AccelerationMeasurements.AddRange(measurements);
            await _context.SaveChangesAsync();
        }
    }
}
