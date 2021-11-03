using System;
using Newtonsoft.Json;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    public class SendUserRegistrationConfirmationEmailCommand : InternalCommandBase
    {
        [JsonConstructor]
        public SendUserRegistrationConfirmationEmailCommand(
            Guid id,
            UserRegistrationId userRegistrationId,
            string email,
            string confirmLink)
            : base(id)
        {
            UserRegistrationId = userRegistrationId;
            Email = email;
            ConfirmLink = confirmLink;
        }

        internal UserRegistrationId UserRegistrationId { get; }

        internal string Email { get; }

        internal string ConfirmLink { get; }
    }
}