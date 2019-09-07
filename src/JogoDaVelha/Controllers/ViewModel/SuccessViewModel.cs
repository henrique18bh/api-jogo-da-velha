using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Controllers.ViewModel
{
    public class SuccessViewModel<TEntity>
    {
        public TEntity Data { get; private set; }

        public SuccessViewModel(TEntity data)
        {
            Data = data;
        }
    }
}
