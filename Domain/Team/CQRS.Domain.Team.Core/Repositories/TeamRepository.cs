using CQRS.Common.Commands;
using Dapper;
using MySql.Data.MySqlClient;
using System;

namespace CQRS.Domain.Team.Core.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly MySqlConnection dbConnection;
        public TeamRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dbConnection = unitOfWork.GetConnection();
        }

        public bool CreateTeam(Model.Team team)
        {
            var command = $"INSERT INTO `apneDB`.`Test` (`Name`) VALUES (\"{team.Name}\")";
            try
            {
                var restult = dbConnection.Execute(command);
                unitOfWork.CommitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool DeleteTeam(Guid id)
        {
            throw new NotImplementedException();
        }

        public Model.Team GetTeamById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
