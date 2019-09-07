using JogoDaVelha.Controllers.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            object response = null;
            response = new ErrorViewModel("InternalServerError", "Ocorreu um erro interno ao processar a requisição.");
            _logger.LogCritical(ex, "Ocorreu um erro interno ao processar a requisição");
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            string result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result, Encoding.UTF8);
        }
    }
}
