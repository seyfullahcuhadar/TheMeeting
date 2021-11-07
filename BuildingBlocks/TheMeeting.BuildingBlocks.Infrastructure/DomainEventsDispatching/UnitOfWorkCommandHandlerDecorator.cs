using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TheMeeting.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default,Guid? internalCommandId = null);
    }
}