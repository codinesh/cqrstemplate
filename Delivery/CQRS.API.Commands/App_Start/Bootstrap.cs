using System;
using CQRS.Domain.Team.Core.Commands;
using CQRS.Common;
using CQRS.Domain.Team;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using CQRS.Domain.Team.Core;

namespace CQRS.API.App_Start
{
    public static class Bootstrapper
    {
        internal static CommandDispatcher Dispatcher { get; private set; }

        public static void DoBootstrap(IServiceCollection services)
        {
            Bootstrapper.Dispatcher = InitializeDispatcher(services);
            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>();

            BootstrapHandlers(services);
        }

        private static CommandDispatcher InitializeDispatcher(IServiceCollection services)
        {
            var dispatcher = new CommandDispatcher
            {
                OnCommandSent = Command =>
                {
                    var name = Command.GetType().Name;
                    return null;
                }
            };

            services.AddSingleton<ICommandDispatcher>(dispatcher);
            services.AddSingleton<IRegisterCommandHandler>(dispatcher);

            return dispatcher;
        }

        private static void BootstrapHandlers(IServiceCollection services)
        {
            var registerHandler = (IRegisterCommandHandler) Dispatcher;
            var serviceProvider = services.BuildServiceProvider();

            TeamBootstrapper.DoBootstrap(registerHandler, serviceProvider);
        }
    }
}
