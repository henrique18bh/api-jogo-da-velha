using JogoDaVelha.CrossCutting.Enum;
using JogoDaVelha.Mapper;
using JogoDaVelha.Model;
using JogoDaVelha.Repository.Interfaces;
using JogoDaVelha.Response;
using JogoDaVelha.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace JogoDaVelha.Service
{
    public class CreateNewGameService : ICreateNewGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IObjectConverter _objectConverter;
        private readonly ILogger _logger;

        public CreateNewGameService(IGameRepository gameRepository,
                                    IObjectConverter objectConverter,
                                    ILogger<CreateNewGameService> logger)
        {
            _gameRepository = gameRepository;
            _objectConverter = objectConverter;
            _logger = logger;
        }

        public CreateNewGameResponse CreateNewGame()
        {
            GameModel game = new GameModel
            {
                Id = Guid.NewGuid(),
                FirstPlayer = DifineFirtPlayer()
            };
            game.NextPlayer = game.FirstPlayer;
            _gameRepository.SaveGame(game);
            _logger.LogInformation("Created Matc {@Id} não encontrado", game.Id);
            return _objectConverter.Map<CreateNewGameResponse>(game);
        }

        private TypePlayer DifineFirtPlayer()
        {
            Array values = Enum.GetValues(typeof(TypePlayer));
            Random random = new Random();
            return (TypePlayer)values.GetValue(random.Next(values.Length));
        }
    }
}
