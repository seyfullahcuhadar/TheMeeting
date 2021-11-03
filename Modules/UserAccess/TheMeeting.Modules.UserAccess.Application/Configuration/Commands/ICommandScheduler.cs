using System.Threading.Tasks;
using TheMeeting.Modules.UserAccess.Application.Contracts;

namespace TheMeeting.Modules.UserAccess.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}