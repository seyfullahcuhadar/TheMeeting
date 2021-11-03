using System;

namespace TheMeeting.BuildingBlocks.Application.InternalCommands
{
    public interface IInternalCommandsMapper
    {
        string GetName(Type type);

        Type GetType(string name);
    }
}