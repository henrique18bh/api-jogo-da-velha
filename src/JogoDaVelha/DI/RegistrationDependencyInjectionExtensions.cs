using JogoDaVelha.Mapper;
using JogoDaVelha.Service;
using JogoDaVelha.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.DI
{
    public static class RegistrationDependencyInjectionExtensions
    {
        public static void AddRegistrationDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddSingleton(configuration);

            RegisterRepositories(services, configuration);
            RegisterServices(services);
            services.AddSingleton<IObjectConverter, ObjectConverter>();
        }

        private static void RegisterRepositories(IServiceCollection services, IConfiguration configuration = null)
        {
            //services.AddTransient<ICachedRepository, CachedRepository>();

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICreateNewGameService, CreateNewGameService>();
        }


    }
}
