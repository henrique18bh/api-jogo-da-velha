using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Controllers.ViewModel
{
    public class MovementViewModel
    {
        public Guid Id { get; set; }
        public TypePlayer Player { get; set; }
        public PositionViewModel Position { get; set; }
    }
}
