using System.Threading.Tasks;
using TheMeeting.BuildingBlocks.Domain;

namespace TheMeeting.Modules.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}