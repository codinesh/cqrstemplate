using CQRS.Common.Query;
using CQRS.Domain.Team.QueryHandlers.BusinessLogic;
using CQRS.Domain.Team.QueryHandlers.Queries;
using CQRS.Domain.Team.QueryHandlers.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Domain.Team.QueryHandlers
{
    public static class DIConfig
    {
        public static void Register(IServiceCollection services)
        {
            RegisterQueryHandlers(services);
            RegisterRepositories(services);
        }

        private static void RegisterQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<TeamByIdQuery, ReadModels.Team>, TeamByIdQueryHandler>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
        }
    }
}
