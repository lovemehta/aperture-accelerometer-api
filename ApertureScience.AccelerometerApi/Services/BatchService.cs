using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for processing batches of acceleration measurements.
    /// </summary>
    public class BatchService : IBatchService
    {
        private readonly IBatchProcessor _batchProcessor;
        private readonly IAsyncConsumer _asyncConsumer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchService"/> class.
        /// </summary>
        /// <param name="batchProcessor">The batch processor.</param>
        /// <param name="asyncConsumer">The asynchronous consumer.</param>
        public BatchService(IBatchProcessor batchProcessor, IAsyncConsumer asyncConsumer)
        {
            _batchProcessor = batchProcessor;
            _asyncConsumer = asyncConsumer;
        }

        /// <summary>
        /// Processes a collection of acceleration measurements asynchronously by batching them.
        /// </summary>
        /// <param name="userId">The ID of the user associated with the measurements.</param>
        /// <param name="measurements">The collection of acceleration measurement requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ProcessMeasurementsAsync(string userId, IEnumerable<AccelerationMeasurementRequest> measurements)
        {
            // Convert measurement requests to measurement entities
            var entities = measurements.Select(m => new AccelerationMeasurement
            {
                Timestamp = m.Timestamp,
                X = m.X,
                Y = m.Y,
                Z = m.Z,
                UserId = userId
            });

            // Create batches of measurement entities
            var batches = _batchProcessor.CreateBatches(entities);

            // Consume each batch asynchronously
            foreach (var batch in batches)
            {
                await _asyncConsumer.ConsumeAsync(batch);
            }
        }
    }
}
