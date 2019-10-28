using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using CQRS.Common.Query;
using CQRS.Domain.Team.QueryHandlers;

namespace CQRS.API.App_Start
{
    public static class Bootstrapper
    {
        internal static QueryHandlerRegister QueryHandler { get; private set; }

        public static void DoBootstrap(IServiceCollection services)
        {
            Bootstrapper.QueryHandler = InitializeQueryHandler(services);
            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetService<IOptions<AppSettings>>();

            BootstrapHandlers(services);
        }

        private static QueryHandlerRegister InitializeQueryHandler(IServiceCollection services)
        {
            var handler = new QueryHandlerRegister();

            services.AddSingleton<IQueryHandlerRegister>(handler);

            return handler;
        }

        private static void BootstrapHandlers(IServiceCollection services)
        {
            var registerHandler = (IQueryHandlerRegister) QueryHandler;
            var serviceProvider = services.BuildServiceProvider();

            TeamBootstrapper.DoBootstrap(registerHandler, serviceProvider);
        }
    }
}
