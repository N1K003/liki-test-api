using System;
using System.Threading.Tasks;
using Liki.Common.Exceptions;
using Liki.Common.Extensions;
using Liki.TestApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Liki.TestApi.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex,
                $"Exception occurred. {ex.Message}");

            var response = ex.ToResponse().SerializeToJson();

            context.Response.ContentType = Constants.DefaultMimeType;
            context.Response.StatusCode = GetStatusCodeByException(ex);
            await context.Response.WriteAsync(response);
        }


        private static int GetStatusCodeByException(Exception ex)
        {
            switch (ex)
            {
                case ValidationException _:
                    return 400;
                case NotFoundException _:
                    return 404;
                default:
                    return 500;
            }
        }
    }
}