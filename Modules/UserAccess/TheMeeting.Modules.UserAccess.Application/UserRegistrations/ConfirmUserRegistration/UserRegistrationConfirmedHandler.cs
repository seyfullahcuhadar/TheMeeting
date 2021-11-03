using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations.Events;
using TheMeeting.Modules.UserAccess.Domain.Users;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class UserRegistrationConfirmedHandler : INotificationHandler<UserRegistrationConfirmedDomainEvent>
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;

        private readonly IUserRepository _userRepository;

        public UserRegistrationConfirmedHandler(
            IUserRegistrationRepository userRegistrationRepository,
            IUserRepository userRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UserRegistrationConfirmedDomainEvent @event, CancellationToken cancellationToken)
        {
            var userRegistration = await _userRegistrationRepository.GetByIdAsync(@event.UserRegistrationId);

            var user = userRegistration.CreateUser();

            await _userRepository.AddAsync(user);
        }
    }
}