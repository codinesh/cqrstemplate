using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Common.Query;
using CQRS.Domain.Team.QueryHandlers.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS.API.Queries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IQueryHandlerRegister queryHandlerRegister;

        public TeamController(ILogger<TeamController> logger, IQueryHandlerRegister queryHandlerRegister)
        {
            _logger = logger;
            this.queryHandlerRegister = queryHandlerRegister;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int teamId)
        {
            var query = new TeamByIdQuery(teamId);
            var result = await queryHandlerRegister.HandleAsync(query);
            return Ok(result);
        }
    }
}
