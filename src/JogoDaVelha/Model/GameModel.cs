using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Model
{
    [Serializable]
    public class GameModel
    {
        public Guid Id { get; set; }
        public TypePlayer FirstPlayer { get; set; }
        public StateGame StateGame { get; set; }
        public TypePlayer NextPlayer { get; set; }
        public BoardModel Board { get; set; }
    }
}
