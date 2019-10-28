using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Domain.Team.Core.Commands;
using CQRS.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CQRS.Common.Commands;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ICommandDispatcher commandDispatcher;
        private readonly AppSettings options;

        public TeamController(ILogger<TeamController> logger, ICommandDispatcher commandDispatcher, IOptions<AppSettings> options)
        {
            _logger = logger;
            this.commandDispatcher = commandDispatcher;
            this.options = options.Value;
        }

        [HttpGet("create")]
        public int CreateTeam(string teamName)
        {
            commandDispatcher.Dispatch(new CreateTeamCommand(Guid.NewGuid(), 1, teamName));

            return 1;
        }
    }
}
