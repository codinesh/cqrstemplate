using System;

namespace CQRS.Common
{
    public interface IRegisterCommandHandler
    {
        void RegisterHandler<T>(Func<ICommandHandler<T>> handler) where T : ICommand;
    }
}