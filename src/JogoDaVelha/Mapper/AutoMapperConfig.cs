using AutoMapper;
using JogoDaVelha.Mapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Mapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings(params Profile[] profiles)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResponseToViewModelProfile());
                cfg.AddProfile(new ModelToResponseProfile());
                cfg.AddProfile(new RequestToRequestProfile());
                cfg.AddProfile(new ResponseToResponseProfile());
            });
        }
    }
}
