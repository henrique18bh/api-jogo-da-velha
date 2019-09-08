using AutoMapper;
using JogoDaVelha.Controllers.ViewModel;
using JogoDaVelha.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Mapper.Profiles
{
    public class ResponseToViewModelProfile : Profile
    {
        public ResponseToViewModelProfile()
        {
            CreateMap<CreateNewGameResponse, GameViewModel>()
                .ForMember(dest => dest.FirstPlayer, opt => opt.MapFrom(src => src.FirstPlayer.ToString()));
            CreateMap<ExecuteMovementResponse, MovementViewModel>()
                .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner.ToString()));

        }
    }
}
