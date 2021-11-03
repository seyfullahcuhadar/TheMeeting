

using TheMeeting.Modules.UserAccess.Application.Contracts;
using TheMeeting.Modules.UserAccess.Application.Users.GetUser;

namespace TheMeeting.Modules.UserAccess.Application.Users.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQuery : QueryBase<UserDto>
    {
        public GetAuthenticatedUserQuery()
        {
        }
    }
}