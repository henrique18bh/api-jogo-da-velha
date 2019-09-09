using JogoDaVelha.CrossCutting.Enum;
using JogoDaVelha.Mapper;
using JogoDaVelha.Model;
using JogoDaVelha.Repository.Interfaces;
using JogoDaVelha.Request;
using JogoDaVelha.Response;
using JogoDaVelha.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaVelha.Service
{
    public class CompileGameService : ICompileGameService
    {
        private readonly IGameRepository _gameRepository;

        public CompileGameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public CompileGameResponse CompileGame(CompileGameRequest request)
        {
            GameModel game = _gameRepository.GetGame(request.Id).Result;

            game.Board.BoardPositions[request.Player]
                .Add(new PositionModel(request.Position.X, request.Position.Y));

            game.StateGame = CompileWinner(game.Board);
            if (game.Board.BoardPositions.Sum(x => x.Value.Count) <= 9 && game.StateGame == StateGame.InProgress)
            {
                game.NextPlayer = request.Player == TypePlayer.X ? TypePlayer.O : TypePlayer.X;
                _gameRepository.SaveGame(game);
                return new CompileGameResponse
                {
                    Msg = "Jogada feita com sucesso"
                };
            }
            _gameRepository.SaveGame(game);
            return new CompileGameResponse
            {
                Msg = "Partida finalizada",
                Status = "Partida finalizada",
                Winner = game.StateGame
            };
        }

        private StateGame CompileWinner(BoardModel board)
        {
            IList<PositionModel> playerX = board.BoardPositions[TypePlayer.X];
            IList<PositionModel> playerO = board.BoardPositions[TypePlayer.O];
            if (ValidetePlayerWinner(playerX))
            {
                return StateGame.X;
            }
            if (ValidetePlayerWinner(playerO))
            {
                return StateGame.O;
            }
            return board.BoardPositions.Sum(x => x.Value.Count) < 9 ? StateGame.InProgress : StateGame.Draw;
        }

        private bool ValidetePlayerWinner(IList<PositionModel> playerPositions)
        {
            return ValidateLine(playerPositions) ||
                   ValidateColumn(playerPositions) ||
                   ValidateDiagonal(playerPositions);
        }

        private static bool ValidateLine(IList<PositionModel> playerPositions)
        {
            for (int y = 0; y < 3; y++)
            {
                bool validLine = false;
                for (int x = 0; x < 3; x++)
                {
                    validLine = playerPositions.Any(p => p.X == x && p.Y == y);
                    if (!validLine)
                    {
                        break;
                    }
                }
                if (validLine)
                {
                    return validLine;
                }
            }
            return false;
        }

        private static bool ValidateColumn(IList<PositionModel> playerPositions)
        {
            for (int x = 0; x < 3; x++)
            {
                bool validColumn = false;
                for (int y = 0; y < 3; y++)
                {
                    validColumn = playerPositions.Any(p => p.X == x && p.Y == y);
                    if (!validColumn)
                    {
                        break;
                    }
                }
                if (validColumn)
                {
                    return validColumn;
                }
            }
            return false;
        }

        private static bool ValidateDiagonal(IList<PositionModel> playerPositions)
        {
            int validDiagonalA = 0;
            int validDiagonalB = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        if (x == y && playerPositions.Any(p => p.X == x && p.Y == y))
                        {
                            validDiagonalA++;
                        }
                        if ((x != y || (x == 1 && y == 1)) && playerPositions.Any(p => p.X == x && p.Y == y))
                        {
                            validDiagonalB++;
                        }
                    }
                }
            }
            return validDiagonalA == 3 || validDiagonalB == 3;
        }
    }
}
