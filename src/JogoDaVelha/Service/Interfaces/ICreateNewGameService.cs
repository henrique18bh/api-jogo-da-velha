using JogoDaVelha.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Service.Interfaces
{
    public interface ICreateNewGameService
    {
        CreateNewGameResponse CreateNewGame();
    }
}
