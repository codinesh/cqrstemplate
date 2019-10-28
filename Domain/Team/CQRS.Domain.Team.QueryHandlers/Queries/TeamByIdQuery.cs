using CQRS.Common;
using System;

namespace CQRS.Domain.Team.QueryHandlers.Queries
{
    public class TeamByIdQuery: QueryBase<ReadModels.Team>
    {
        public TeamByIdQuery(int teamId)
        {
            TeamId = teamId;
        }

        public int TeamId { get; }
    }
}
