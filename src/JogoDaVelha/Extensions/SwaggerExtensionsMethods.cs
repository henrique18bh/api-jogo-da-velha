using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Extensions
{
    public static class SwaggerExtensionsMethods
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationName = $"{configuration.GetSection("Application").GetValue<string>("ApplicationName")}";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = applicationName, Version = "V1" });
            });
        }
    }
}
