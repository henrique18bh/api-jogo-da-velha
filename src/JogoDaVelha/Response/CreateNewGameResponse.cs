using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Response
{
    public class CreateNewGameResponse
    {
        public Guid Id { get; set; }
        public TypePlayer FirstPlayer { get; set; }
    }
}
