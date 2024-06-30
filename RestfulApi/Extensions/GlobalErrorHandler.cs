using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Entity.Exceptions;

namespace RestfulApi.Extensions
{
    public class GlobalErrorHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not null)
            {

                //var problemDetails = new ProblemDetails
                //{
                //    Status = StatusCodes.Status500InternalServerError,
                //    Title = "Server error"
                //};

                var statusCodes = exception switch
                {
                    ProductNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError,
                };
                httpContext.Response.StatusCode = statusCodes;

                var error = new
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = exception.Message
                };
                await httpContext.Response
                    .WriteAsJsonAsync(error, cancellationToken);

                return true;
            }
            return false;
        }
    }
}
