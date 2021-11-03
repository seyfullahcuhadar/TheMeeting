
using System;
using TheMeeting.Modules.UserAccess.Application.Contracts;

namespace TheMeeting.Modules.UserAccess.Application.Users.GetUser
{
    public class GetUserQuery : QueryBase<UserDto>
    {
        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}