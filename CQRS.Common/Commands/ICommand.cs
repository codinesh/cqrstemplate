using System;

namespace CQRS.Common
{
    public interface ICommand : IMessage
    {
        Guid Id { get; }
    }
}
