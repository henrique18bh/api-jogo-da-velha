using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogoDaVelha.Controllers.ViewModel;
using JogoDaVelha.Mapper;
using JogoDaVelha.Request;
using JogoDaVelha.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JogoDaVelha.Controllers
{
    [Route("game/{id}/movement")]
    [ApiController]
    public class GameMovementController : ControllerBase
    {

        private readonly IExecuteMovementService _executeMovementService;
        private readonly IObjectConverter _objectConverter;
        public GameMovementController(IExecuteMovementService executeMovementService,
                                 IObjectConverter objectConverter)
        {
            _executeMovementService = executeMovementService;
            _objectConverter = objectConverter;

        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "New Movement",
            Description = "Define a new movement in this game",
            OperationId = "Movement"
        )]
        [ProducesResponseType(typeof(SuccessViewModel<MovementViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody]ExecuteMovementRequest request)
        {
            var response = _executeMovementService.ExecuteMovement(request);
            return Ok(BuildSuccessResponse(_objectConverter.Map<MovementViewModel>(response)));
        }
    }
}