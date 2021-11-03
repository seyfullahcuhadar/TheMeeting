using System;
using MediatR;

namespace TheMeeting.BuildingBlocks.Domain
{
    public interface IDomainEvent: INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}