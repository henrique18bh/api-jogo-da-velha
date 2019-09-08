using AutoMapper;
using JogoDaVelha.Request;
using System;

namespace JogoDaVelha.Mapper.Profiles
{
    public class RequestToRequestProfile : Profile
    {
        public RequestToRequestProfile()
        {
            CreateMap<ExecuteMovementRequest, ValidateGameRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ParseGuid(src.Id)));
            CreateMap<ExecuteMovementRequest, CompileGameRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ParseGuid(src.Id)));
        }

        private Guid ParseGuid(string value)
        {
            if (Guid.TryParse(value, out Guid result))
            {
                return result;
            }
            return Guid.Empty;
        }
    }
}
