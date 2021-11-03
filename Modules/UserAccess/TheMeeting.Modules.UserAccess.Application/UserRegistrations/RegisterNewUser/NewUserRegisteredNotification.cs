using System;
using Newtonsoft.Json;
using TheMeeting.BuildingBlocks.Application.Events;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations.Events;

namespace TheMeeting.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredNotification : DomainNotificationBase<NewUserRegisteredDomainEvent>
    {
        [JsonConstructor]
        public NewUserRegisteredNotification(NewUserRegisteredDomainEvent domainEvent, Guid id)
            : base(domainEvent, id)
        {
        }
    }
}