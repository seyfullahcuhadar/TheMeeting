using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Newtonsoft.Json;
using TheMeeting.BuildingBlocks.Application.Data;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;

namespace TheMeeting.Modules.UserAccess.Infrastructure.Configuration.Processing.Inbox
{
    internal class ProcessInboxCommandHandler : ICommandHandler<ProcessInboxCommand>
    {
        private readonly IMediator _mediator;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessInboxCommandHandler(IMediator mediator, ISqlConnectionFactory sqlConnectionFactory)
        {
            _mediator = mediator;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<Unit> Handle(ProcessInboxCommand command, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
                         $"[InboxMessage].[Id] AS [{nameof(InboxMessageDto.Id)}], " +
                         $"[InboxMessage].[Type] AS [{nameof(InboxMessageDto.Type)}], " +
                         $"[InboxMessage].[Data] AS [{nameof(InboxMessageDto.Data)}] " +
                         "FROM [users].[InboxMessages] AS [InboxMessage] " +
                         "WHERE [InboxMessage].[ProcessedDate] IS NULL " +
                         "ORDER BY [InboxMessage].[OccurredOn]";

            var messages = await connection.QueryAsync<InboxMessageDto>(sql);

            const string sqlUpdateProcessedDate = "UPDATE [users].[InboxMessages] " +
                                                  "SET [ProcessedDate] = @Date " +
                                                  "WHERE [Id] = @Id";

            foreach (var message in messages)
            {
                var messageAssembly = AppDomain.CurrentDomain.GetAssemblies()
                    .SingleOrDefault(assembly => message.Type.Contains(assembly.GetName().Name));

                Type type = messageAssembly.GetType(message.Type);
                var request = JsonConvert.DeserializeObject(message.Data, type);

                try
                {
                    await _mediator.Publish((INotification)request, cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                {
                    Date = DateTime.UtcNow,
                    message.Id
                });
            }

            return Unit.Value;
        }
    }
}