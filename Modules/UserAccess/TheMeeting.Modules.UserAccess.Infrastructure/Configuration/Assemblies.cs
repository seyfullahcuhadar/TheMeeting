using System.Reflection;
using TheMeeting.Modules.UserAccess.Application.Configuration.Commands;

namespace TheMeeting.Modules.UserAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}