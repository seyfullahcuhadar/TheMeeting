using System;
using System.Threading;
using System.Threading.Tasks;
using TheMeeting.Modules.UserAccess.Application.Authentication;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler:ICommandHandler<RegisterNewUserCommand,Guid>
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUsersCounter _usersCounter;

        public RegisterNewUserCommandHandler(
            IUserRegistrationRepository userRegistrationRepository,
            IUsersCounter usersCounter)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _usersCounter = usersCounter;
        }
        
        
        
        
        public async Task<Guid> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordManager.HashPassword(request.Password);
            var userRegistration =  UserRegistration.RegisterNewUser(
                request.Login,
                password,
                request.Email,
                request.FirstName,
                request.LastName,
                _usersCounter,
                request.ConfirmLink);
            await this._userRegistrationRepository.AddAsync(userRegistration);
            return userRegistration.Id.Value;
        }
    }
}