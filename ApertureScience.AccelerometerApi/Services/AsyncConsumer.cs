using System.Collections.Generic;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;
using ApertureScience.AccelerometerApi.Data;

namespace ApertureScience.AccelerometerApi.Services
{
    public class AsyncConsumer : IAsyncConsumer
    {
        private readonly ApplicationDbContext _context;

        public AsyncConsumer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ConsumeAsync(IEnumerable<AccelerationMeasurement> measurements)
        {
            _context.AccelerationMeasurements.AddRange(measurements);
            await _context.SaveChangesAsync();
        }
    }
}
