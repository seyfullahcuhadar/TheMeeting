using Autofac;
using TheMeeting.Modules.UserAccess.Application.UserRegistrations;
using TheMeeting.Modules.UserAccess.Domain.UserRegistrations;

namespace TheMeeting.Modules.UserAccess.Infrastructure.Configuration.DataAccess.Domain
{
    internal class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersCounter>()
                .As<IUsersCounter>()
                .InstancePerLifetimeScope();
        }
    }
}