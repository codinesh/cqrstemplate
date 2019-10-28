using CQRS.Common;
using System;

namespace CQRS.Domain.Team.Core.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(Guid id, int version, string name) : base(id, version)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

}
