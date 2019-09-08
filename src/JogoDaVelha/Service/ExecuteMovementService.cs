using JogoDaVelha.Mapper;
using JogoDaVelha.Request;
using JogoDaVelha.Response;
using JogoDaVelha.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace JogoDaVelha.Service
{
    public class ExecuteMovementService : IExecuteMovementService
    {
        private readonly IValidateGameService _validateGameService;
        private readonly ICompileGameService _compileGameService;
        private readonly IObjectConverter _objectConverter;

        public ExecuteMovementService(IValidateGameService validateGameService,
                                      ICompileGameService compileGameService,
                                      IObjectConverter objectConverter)
        {
            _validateGameService = validateGameService;
            _compileGameService = compileGameService;
            _objectConverter = objectConverter;
        }
        public ExecuteMovementResponse ExecuteMovement(ExecuteMovementRequest request)
        {
            ValidateGameRequest validateRequest = _objectConverter.Map<ValidateGameRequest>(request);
            string validate = _validateGameService.ValidateGame(validateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                return new ExecuteMovementResponse
                {
                    Msg = validate
                };
            }
            CompileGameResponse compileResponse = _compileGameService.CompileGame(_objectConverter.Map<CompileGameRequest>(request));
            return _objectConverter.Map<ExecuteMovementResponse>(compileResponse);
        }
    }
}
