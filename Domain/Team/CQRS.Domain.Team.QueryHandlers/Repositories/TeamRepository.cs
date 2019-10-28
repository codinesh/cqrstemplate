using CQRS.Common;
using CQRS.Domain.Team.QueryHandlers.ReadModels;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Domain.Team.QueryHandlers.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MySqlConnection dbConnection;
        public TeamRepository(MySqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<ReadModels.Team> FetchTeamById(int teamId)
        {
            var query = $"SELECT * FROM `apneDB`.`Test` WHERE Id = {teamId}";
            try
            {
                var restult = await dbConnection.QueryFirstAsync<ReadModels.Team>(query);
                return restult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
