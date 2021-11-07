using System.Threading.Tasks;
using Serilog;
using TheMeeting.BuildingBlocks.Infrastructure.EventBus;

namespace TheMeeting.BuildingBlocks.EventBus
{
    public class InMemoryEventBusClient : IEventsBus
    {
        private readonly ILogger _logger;

        public InMemoryEventBusClient(ILogger logger)
        {
            _logger = logger;
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task Publish<T>(T @event) where T : IntegrationEvent
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            throw new System.NotImplementedException();
        }

        public void StartConsuming()
        {
            throw new System.NotImplementedException();
        }
    }
}