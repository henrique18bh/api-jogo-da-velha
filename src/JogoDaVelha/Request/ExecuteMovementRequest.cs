using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Request
{
    public class ExecuteMovementRequest
    {
        public string Id { get; set; }
        public TypePlayer Player { get; set; }
        public PositionRequest Position { get; set; }
    }
}
