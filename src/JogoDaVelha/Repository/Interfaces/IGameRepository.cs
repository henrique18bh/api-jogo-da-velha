using JogoDaVelha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Repository.Interfaces
{
    public interface IGameRepository
    {
         Task<GameModel> GetGame(Guid id);
        void SaveGame(GameModel game);
    }
}
