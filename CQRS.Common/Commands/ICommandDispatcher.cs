using CQRS.Common;

namespace CQRS.Common
{
    public interface ICommandDispatcher
    {
        System.Func<object, object> OnCommandSent { get; set; }

        void Dispatch<T>(T command) where T : ICommand;
    }

}
