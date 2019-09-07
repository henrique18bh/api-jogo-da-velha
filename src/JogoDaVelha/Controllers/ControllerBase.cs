using JogoDaVelha.Controllers.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Controllers
{
    public class ControllerBase : Controller
    {

        protected SuccessViewModel<TEntity> BuildSuccessResponse<TEntity>(TEntity response)
        {
            return new SuccessViewModel<TEntity>(response);
        }
    }
}
