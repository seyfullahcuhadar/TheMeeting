using TheMeeting.BuildingBlocks.Domain;

namespace TheMeeting.Modules.UserAccess.Domain.Users
{
    public class UserRole : ValueObject
    {
        public static UserRole Member => new UserRole(nameof(Member));

        public string Value { get; }

        private UserRole(string value)
        {
            this.Value = value;
        }
    }
}