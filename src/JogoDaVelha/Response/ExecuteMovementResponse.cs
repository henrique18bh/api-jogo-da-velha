using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Response
{
    public class ExecuteMovementResponse
    {
        public string Msg { get; set; }
        public string Status { get; set; }
        public StateGame Winner { get; set; }
    }
}
