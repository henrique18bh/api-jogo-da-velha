using JogoDaVelha.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Service.Interfaces
{
    public interface IValidateGameService
    {
        string ValidateGame(ValidateGameRequest request);
    }
}
