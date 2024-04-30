using Elmah.Io.AspNetCore;
using System.Net;

namespace LHF.Api.Extensions
{
    //Middleware conectado com Elmah.
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private static void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            exception.Ship(context); // simular o erro na v2
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}