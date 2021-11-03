

using System.Threading;
using System.Threading.Tasks;
using Dapper;
using TheMeeting.BuildingBlocks.Application;
using TheMeeting.BuildingBlocks.Application.Data;
using TheMeeting.Modules.UserAccess.Application.Configuration.Queries;
using TheMeeting.Modules.UserAccess.Application.Users.GetUser;

namespace TheMeeting.Modules.UserAccess.Application.Users.GetAuthenticatedUser
{
    internal class GetAuthenticatedUserQueryHandler : IQueryHandler<GetAuthenticatedUserQuery, UserDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAuthenticatedUserQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory,
            IExecutionContextAccessor executionContextAccessor)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<UserDto> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT" +
                               "[User].[Id], " +
                               "[User].[IsActive], " +
                               "[User].[Login], " +
                               "[User].[Email], " +
                               "[User].[Name] " +
                               "FROM [users].[v_Users] AS [User] " +
                               "WHERE [User].[Id] = @UserId";

            return await connection.QuerySingleAsync<UserDto>(sql, new
            {
                _executionContextAccessor.UserId
            });
        }
    }
}