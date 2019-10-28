using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API.App_Start
{
    public static class DIConfig
    {
        public static void Register(IServiceCollection services)
        {
            Domain.Team.Core.DIConfig.Register(services);
        }
    }
}
