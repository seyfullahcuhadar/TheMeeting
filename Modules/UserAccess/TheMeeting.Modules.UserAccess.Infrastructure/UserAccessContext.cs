using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheMeeting.BuildingBlocks.Application.InternalCommands;
using TheMeeting.BuildingBlocks.Application.Outbox;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;
using TheMeeting.Modules.UserAccess.Domain.Users;
using TheMeeting.Modules.UserAccess.Infrastructure.Domain.UserRegistrations;
using TheMeeting.Modules.UserAccess.Infrastructure.Domain.Users;
using TheMeeting.Modules.UserAccess.Infrastructure.InternalCommands;
using TheMeeting.Modules.UserAccess.Infrastructure.Outbox;

namespace TheMeeting.Modules.UserAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<UserRegistration> UserRegistrations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public UserAccessContext(DbContextOptions options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxMessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }
    }
}