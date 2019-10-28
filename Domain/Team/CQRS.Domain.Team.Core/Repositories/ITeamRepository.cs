using CQRS.Common;
using CQRS.Domain.Team.Core.Model;
using Dapper;
using System;

namespace CQRS.Domain.Team.Core.Repository
{
    public interface ITeamRepository : IWriteRepository
    {
        Model.Team GetTeamById(Guid id);

        bool CreateTeam(Model.Team team);

        bool DeleteTeam(Guid id);
    }
}
