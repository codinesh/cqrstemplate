namespace CQRS.Common
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void HandleAsync(T command);
    }
}
