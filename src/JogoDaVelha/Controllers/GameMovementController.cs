using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogoDaVelha.Controllers.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JogoDaVelha.Controllers
{
    [Route("game/{id}/movement")]
    [ApiController]
    public class GameMovementController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "New Movement",
            Description = "Define a new movement in this game",
            OperationId = "Movement"
        )]
        [ProducesResponseType(typeof(SuccessViewModel<ReturnMovementViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromRoute]Guid id, [FromBody] MovementViewModel request)
        {
            return Ok('1');
        }
    }
}