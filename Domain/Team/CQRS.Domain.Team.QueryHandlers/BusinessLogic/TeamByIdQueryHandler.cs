using CQRS.Common.Query;
using CQRS.Domain.Team.QueryHandlers.Queries;
using CQRS.Domain.Team.QueryHandlers.Repositories;using System.Threading.Tasks;

namespace CQRS.Domain.Team.QueryHandlers.BusinessLogic
{
    public class TeamByIdQueryHandler : QueryHandler<TeamByIdQuery, ReadModels.Team>
    {
        private readonly ITeamRepository teamRepository;

        public TeamByIdQueryHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public override async Task<ReadModels.Team> HandleAsync(TeamByIdQuery query)
        {
            var team  = await this.teamRepository.FetchTeamById(query.TeamId);
            return team;
        }
    }
}
