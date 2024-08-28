using Microsoft.AspNetCore.Diagnostics;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Responses;

namespace OnlineShop.Presentation.Middlewares;

public sealed class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        //var response = new ErrorResponse("Unexpected error occured", 500);

        var response = exception switch
        {
            EnumException => new ErrorResponse(exception.Message, 400),
            _ => new ErrorResponse("Unexpected error occured", 500)
        };

        httpContext.Response.StatusCode = response.StatusCode;

        await httpContext.Response
            .WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}