using System.Collections.Generic;
using TheMeeting.BuildingBlocks.Infrastructure.EventBus;

namespace TheMeeting.BuildingBlocks.EventBus
{
    public sealed class InMemoryEventBus
    {
        private readonly IDictionary<string, List<IIntegrationEventHandler>> _handlersDictionary;


        static InMemoryEventBus()
        {
        }
        public static InMemoryEventBus Instance { get; } = new InMemoryEventBus();

        private InMemoryEventBus()
        {
            _handlersDictionary = new Dictionary<string, List<IIntegrationEventHandler>>();
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            var eventType = typeof(T).FullName;
            if (eventType != null)
            {
                if (_handlersDictionary.ContainsKey(eventType))
                {
                    var handlers = _handlersDictionary[eventType];
                    handlers.Add(handler);
                }
                else
                {
                    _handlersDictionary.Add(eventType,new List<IIntegrationEventHandler>{handler});
                }
            }
        }
        
        
    }
}