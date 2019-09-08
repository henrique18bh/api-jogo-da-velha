using JogoDaVelha.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Model
{
    [Serializable]
    public class BoardModel
    {
        public BoardModel()
        {
            BoardPositions = new Dictionary<TypePlayer, IList<PositionModel>>();
            BoardPositions.Add(TypePlayer.X, new List<PositionModel>());
            BoardPositions.Add(TypePlayer.O, new List<PositionModel>());
        }
        public IDictionary<TypePlayer, IList<PositionModel>> BoardPositions { get; set; }
    }
}
