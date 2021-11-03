using System;
using TheMeeting.BuildingBlocks.Domain;

namespace TheMeeting.Modules.UserAccess.Domain.Users
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value)
            : base(value)
        {
        }
    }
}