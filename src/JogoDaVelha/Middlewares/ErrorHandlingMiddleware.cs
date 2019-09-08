using JogoDaVelha.Controllers.ViewModel;
using JogoDaVelha.CrossCutting.Exceptions;
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
            if (ex is BusinessException)
            {
                response = new ErrorViewModel("UnprocessableEntity", ex.Message);
                statusCode = StatusCodes.Status422UnprocessableEntity;
                _logger.LogError(ex, "Ocorreu um erro interno ao processar a requisição");
            }
            else if (ex is NotFoundException)
            {
                response = new ErrorViewModel("NotFound", ex.Message);
                statusCode = StatusCodes.Status404NotFound;
                _logger.LogInformation(ex, $"Dados não encontrados - {ex.Message}");
            }
            else
            {
                response = new ErrorViewModel("InternalServerError", "Ocorreu um erro interno ao processar a requisição.");
                _logger.LogCritical(ex, "Ocorreu um erro interno ao processar a requisição");
            }
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            string result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result, Encoding.UTF8);
        }
    }
}
