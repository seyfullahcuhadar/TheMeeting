using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;
using TheMeeting.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredEnqueueEmailConfirmationHandler : INotificationHandler<NewUserRegisteredNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;
        public NewUserRegisteredEnqueueEmailConfirmationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }
        public async Task Handle(NewUserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new SendUserRegistrationConfirmationEmailCommand(
                Guid.NewGuid(),
                notification.DomainEvent.UserRegistrationId,
                notification.DomainEvent.Email,
                notification.DomainEvent.ConfirmLink));
        }
    }
}