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
    [Route("api/game")]
    [ApiController]
    public class NewGameController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "New Game",
            Description = "Define a new game",
            OperationId = "Game"
        )]
        [ProducesResponseType(typeof(SuccessViewModel<GameViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post()
        {
            return Ok('1');
        }
    }
}