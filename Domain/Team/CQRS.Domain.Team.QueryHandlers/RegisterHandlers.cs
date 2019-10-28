using CQRS.Common.Query;
using CQRS.Domain.Team.QueryHandlers.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRS.Domain.Team.QueryHandlers
{
    public static class TeamBootstrapper
    {
        public static void DoBootstrap(IQueryHandlerRegister queryHandlerRegister, IServiceProvider serviceProvider)
        {
            queryHandlerRegister?.Register(() => serviceProvider.GetRequiredService<IQueryHandler<TeamByIdQuery, ReadModels.Team>>());
        }
    }
}