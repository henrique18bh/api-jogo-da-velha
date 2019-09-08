using AutoMapper;
using JogoDaVelha.Request;
using JogoDaVelha.Response;

namespace JogoDaVelha.Mapper.Profiles
{
    public class ResponseToResponseProfile : Profile
    {
        public ResponseToResponseProfile()
        {
            CreateMap<CompileGameResponse, ExecuteMovementResponse>();
        }
    }
}
