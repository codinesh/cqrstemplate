using CQRS.Common;
using CQRS.Domain.Team.Core.Commands;
using CQRS.Domain.Team.Core.Repository;

namespace CQRS.Domain.Team.Core.BusinessLogic
{
    public class CreateTeamCommandHandler : CommandHandlerBase<CreateTeamCommand>
    {
        private readonly ITeamRepository teamRepository;

        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        protected override void InternalHandle(CreateTeamCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new InvalidTeamException($"{nameof(command.Name)} is invalid");
            }

            var team = new Model.Team
            {
                Name = command.Name
            };

            teamRepository.CreateTeam(team);
        }
    }
}