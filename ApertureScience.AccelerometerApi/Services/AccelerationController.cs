using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Data;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ApertureScience.AccelerometerApi.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly ApplicationDbContext _context;

        public AccelerationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task IngestMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            var entities = measurements.Select(m => new AccelerationMeasurement
            {
                Timestamp = m.Timestamp,
                X = m.X,
                Y = m.Y,
                Z = m.Z,
                UserId = userId
            });

            await _context.AccelerationMeasurements.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
