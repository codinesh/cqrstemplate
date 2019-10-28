namespace CQRS.Common
{
    public abstract class CommandHandlerBase<T> : ICommandHandler<T>
        where T : ICommand
    {
        public void HandleAsync(T command)
        {
            Validate(command);
            InternalHandle(command);
        }

        protected abstract void InternalHandle(T command);

        private bool Validate(T command)
        {
            return command != null;
        }
    }
}
