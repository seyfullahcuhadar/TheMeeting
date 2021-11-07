using Autofac;
using TheMeeting.BuildingBlocks.EventBus;
using TheMeeting.BuildingBlocks.Infrastructure.EventBus;

namespace TheMeeting.Modules.UserAccess.Infrastructure.Configuration.EventsBus

{
    internal class EventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}