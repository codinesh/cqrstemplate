using CQRS.Common;
using CQRS.Domain.Team.Core.BusinessLogic;
using CQRS.Domain.Team.Core.Commands;
using CQRS.Domain.Team.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Domain.Team.Core
{
    public static class DIConfig
    {
        public static void Register(IServiceCollection services)
        {
            RegisterCommandHandlers(services);
            RegisterRepositories(services);
        }

        private static void RegisterCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateTeamCommand>, CreateTeamCommandHandler>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
        }
    }
}
