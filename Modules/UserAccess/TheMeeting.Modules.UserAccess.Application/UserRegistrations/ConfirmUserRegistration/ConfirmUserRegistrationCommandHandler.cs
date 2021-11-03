using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    internal class ConfirmUserRegistrationCommandHandler : ICommandHandler<ConfirmUserRegistrationCommand>
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;

        public ConfirmUserRegistrationCommandHandler(IUserRegistrationRepository userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
        }

        public async Task<Unit> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userRegistration =
                await _userRegistrationRepository.GetByIdAsync(new UserRegistrationId(request.UserRegistrationId));

            userRegistration.Confirm();

            return Unit.Value;
        }
    }
}