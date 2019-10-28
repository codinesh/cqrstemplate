using System;
using System.Collections.Generic;

namespace CQRS.Common
{
    public class CommandDispatcher : ICommandDispatcher, IRegisterCommandHandler
    {
        private const string Message = "Command already registered.";
        private readonly Dictionary<Type, dynamic> commandHandlers = new Dictionary<Type, dynamic>();

        public Func<object, object> OnCommandSent { get; set; }

        public void RegisterHandler<T>(Func<ICommandHandler<T>> handler) where T : ICommand
        {
            if (commandHandlers.TryGetValue(typeof(T), out dynamic handler1))
            {
                throw new Exception(Message);
            }

            commandHandlers.Add(typeof(T), handler);
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            Func<ICommandHandler<ICommand>> handler1;
            if (commandHandlers.TryGetValue(typeof(T), out dynamic handler))
            {
                handler().HandleAsync(command);
                dynamic h = commandHandlers[typeof(T)]();
                h.HandleAsync(command);
            }
            else
            {
                throw new InvalidOperationException("no handler registered");
            }
        }
    }
}
