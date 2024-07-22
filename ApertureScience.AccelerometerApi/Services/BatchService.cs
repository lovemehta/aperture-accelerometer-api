using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    public class BatchService : IBatchService
    {
        private readonly IBatchProcessor _batchProcessor;
        private readonly IAsyncConsumer _asyncConsumer;

        public BatchService(IBatchProcessor batchProcessor, IAsyncConsumer asyncConsumer)
        {
            _batchProcessor = batchProcessor;
            _asyncConsumer = asyncConsumer;
        }

        public async Task ProcessMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            var entities = measurements.Select(m => new AccelerationMeasurement
            {
                Timestamp = m.Timestamp,
                X = m.X,
                Y = m.Y,
                Z = m.Z,
                UserId = userId
            });

            var batches = _batchProcessor.CreateBatches(entities, 1000);
            foreach (var batch in batches)
            {
                await _asyncConsumer.ConsumeAsync(batch);
            }
        }
    }
}
