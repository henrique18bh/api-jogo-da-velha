using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogoDaVelha.Controllers.ViewModel;
using JogoDaVelha.Mapper;
using JogoDaVelha.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JogoDaVelha.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class NewGameController : ControllerBase
    {
        private readonly ICreateNewGameService _createNewGameService;
        private readonly IObjectConverter _objectConverter;
        public NewGameController(ICreateNewGameService createNewGameService,
                                 IObjectConverter objectConverter)
        {
            _createNewGameService = createNewGameService;
            _objectConverter = objectConverter;

        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "New Game",
            Description = "Define a new game",
            OperationId = "Game"
        )]
        [ProducesResponseType(typeof(SuccessViewModel<GameViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post()
        {
            var response = _createNewGameService.CreateNewGame();
            return Ok(BuildSuccessResponse(_objectConverter.Map<GameViewModel>(response)));
        }
    }
}