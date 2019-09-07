using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Controllers.ViewModel
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string FirstPlayer { get; set; }
    }
}
