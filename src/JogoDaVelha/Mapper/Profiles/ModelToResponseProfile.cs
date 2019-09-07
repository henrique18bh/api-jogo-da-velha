using AutoMapper;
using JogoDaVelha.Model;
using JogoDaVelha.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Mapper.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<GameModel, CreateNewGameResponse>();
        }
    }
}
