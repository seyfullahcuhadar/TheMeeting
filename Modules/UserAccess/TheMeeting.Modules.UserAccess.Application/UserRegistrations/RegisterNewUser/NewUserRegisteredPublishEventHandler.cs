using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TheMeeting.BuildingBlocks.Infrastructure.EventBus;
using TheMeeting.Modules.UserAccess.IntegrationEvents;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredPublishEventHandler : INotificationHandler<NewUserRegisteredNotification>
    {
        private readonly IEventsBus _eventsBus;

        public NewUserRegisteredPublishEventHandler(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public async Task Handle(NewUserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            await _eventsBus.Publish(new NewUserRegisteredIntegrationEvent(
                notification.Id,
                notification.DomainEvent.OccurredOn,
                notification.DomainEvent.UserRegistrationId.Value,
                notification.DomainEvent.Login,
                notification.DomainEvent.Email,
                notification.DomainEvent.FirstName,
                notification.DomainEvent.LastName,
                notification.DomainEvent.Name));
        }
    }
}