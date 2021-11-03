using System;
using TheMeeting.BuildingBlocks.Domain;

namespace TheMeeting.Modules.UserAccess.Domain.UserRegistrations
{
    public class UserRegistrationId : TypedIdValueBase
    {
        public UserRegistrationId(Guid value)
            : base(value)
        {
        }
    }
}