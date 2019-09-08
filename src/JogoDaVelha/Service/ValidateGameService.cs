using JogoDaVelha.CrossCutting.Exceptions;
using JogoDaVelha.Mapper;
using JogoDaVelha.Model;
using JogoDaVelha.Repository.Interfaces;
using JogoDaVelha.Request;
using JogoDaVelha.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace JogoDaVelha.Service
{
    public class ValidateGameService : IValidateGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ILogger _logger;

        public ValidateGameService(IGameRepository gameRepository,
                                   ILogger<CreateNewGameService> logger)
        {
            _gameRepository = gameRepository;
            _logger = logger;
        }

        public string ValidateGame(ValidateGameRequest request)
        {
            GameModel game = _gameRepository.GetGame(request.Id).Result;
            if (game == null)
            {
                _logger.LogInformation("Game not found {@Id}", request.Id);
                throw new NotFoundException("Partida não encontrada");
            }
            if (game.StateGame != CrossCutting.Enum.StateGame.InProgress)
            {
                _logger.LogInformation("This match is already over {@Id}", request.Id);
                throw new BusinessException("Esta partida já acabou");
            }
            if (game.NextPlayer != request.Player)
            {
                _logger.LogInformation("It's not player turn {@Player}", request.Player);
                throw new BusinessException("Não é turno do jogador");
            }

            bool validatePositionFilled = ValidatePositionFilled(game.Board, request.Position);
            bool validateAllPositionsFilled = ValidateAllPositionsFilled(game.Board);
            bool validateMaxPosition = ValidateMaxPosition(request.Position);

            if (validatePositionFilled || validateAllPositionsFilled || validateMaxPosition)
            {
                _logger.LogInformation("Invalid movement {@Id}", request.Id);
                throw new BusinessException("Movimento inválido");
            }

            return string.Empty;
        }

        private bool ValidatePositionFilled(BoardModel board, PositionRequest position)
        {
            foreach (var boardPosition in board.BoardPositions)
            {
                if (boardPosition.Value.Any(pl => pl.X == position.X && pl.Y == position.Y))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateAllPositionsFilled(BoardModel board)
        {
            return board.BoardPositions.Sum(x => x.Value.Count) >= 9;
        }

        private bool ValidateMaxPosition(PositionRequest position)
        {
            return position.X > 2 || position.Y > 2;
        }
    }
}
