using MediatR;
using TheMeeting.Modules.UserAccess.Application.Contracts;

namespace TheMeeting.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}