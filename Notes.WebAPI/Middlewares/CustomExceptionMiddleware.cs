using Notes.Persistance.Exceptions;
using System.Diagnostics.Metrics;
using System;
using System.Net;
using FluentValidation;

namespace Notes.WebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(
            RequestDelegate next,
            ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(EntityNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                await BadRequestExceptionHanlder(context, ex);
            }
            catch(ValidationException ex)
            {
                _logger.LogWarning(ex.Message);
                await BadRequestExceptionHanlder(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorServerExceptionHandler(context, ex);
            }
        }

        private async Task ErrorServerExceptionHandler(HttpContext context, Exception ex)
        {
            var response = context.Response;
            var responseData = new
            {
                code = HttpStatusCode.InternalServerError,
                message = ex.Message,
            };

            response.ContentType = "application/json";
            response.StatusCode = (int)responseData.code;
            await response.WriteAsJsonAsync(responseData);
        }

        private async Task BadRequestExceptionHanlder(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var responseData = new
            {
                code = HttpStatusCode.BadRequest,
                message = exception.Message,
            };

            response.ContentType = "application/json";
            response.StatusCode = (int)responseData.code;
            await response.WriteAsJsonAsync(responseData);
        }
    }
}
