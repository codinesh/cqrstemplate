using CQRS.Domain.Team.Core.Commands;
using CQRS.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRS.Domain.Team.Core
{
    public static class TeamBootstrapper
    {
        public static void DoBootstrap(IRegisterCommandHandler registerCommandHandler, IServiceProvider serviceProvider)
        {
            registerCommandHandler.RegisterHandler(() => serviceProvider.GetRequiredService<ICommandHandler<CreateTeamCommand>>());
        }
    }
}