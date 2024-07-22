using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Data;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for handling acceleration measurements.
    /// </summary>
    public class AccelerationService : IAccelerationService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccelerationService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public AccelerationService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ingests a collection of acceleration measurements for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the measurements are being ingested.</param>
        /// <param name="measurements">A collection of acceleration measurement requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task IngestMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            // Map the measurement requests to the entity model
            var entities = measurements.Select(m => new AccelerationMeasurement
            {
                Timestamp = m.Timestamp,
                X = m.X,
                Y = m.Y,
                Z = m.Z,
                UserId = userId
            });

            // Add the new measurements to the context
            await _context.AccelerationMeasurements.AddRangeAsync(entities);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }
    }
}
