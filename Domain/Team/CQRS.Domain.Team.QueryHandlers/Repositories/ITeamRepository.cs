using CQRS.Common;
using System;
using System.Threading.Tasks;

namespace CQRS.Domain.Team.QueryHandlers.Repositories
{
    public interface ITeamRepository : IReadRepository
    {
        Task<ReadModels.Team> FetchTeamById(int teamId);
    }
}