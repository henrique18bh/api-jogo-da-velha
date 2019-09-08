using JogoDaVelha.Mapper;
using JogoDaVelha.Repository;
using JogoDaVelha.Repository.Interfaces;
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
            services.AddSingleton<IObjectConverter, ObjectConverter>();

            RegisterRepositories(services);
            RegisterServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IGameRepository, GameRepository>();

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICreateNewGameService, CreateNewGameService>();
            services.AddScoped<IExecuteMovementService, ExecuteMovementService>();
            services.AddScoped<ICompileGameService, CompileGameService>();
            services.AddScoped<IValidateGameService, ValidateGameService>();
        }


    }
}
