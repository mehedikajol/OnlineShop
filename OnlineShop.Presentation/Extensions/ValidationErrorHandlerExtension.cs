using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Responses;

namespace OnlineShop.Presentation.Extensions;

public static class ValidationErrorHandlerExtension
{
    public static ObjectResult HandlerValidationErrors(this ActionContext context)
    {
        var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage.ToLowerInvariant())
                    .ToList();

        errors = errors
            .Select(p => p.Substring(0, 1).ToUpper() + p.Substring(1))
            .ToList();

        var response = new ValidationErrorResponse(errors);

        return new BadRequestObjectResult(response)
        {
            ContentTypes = { "application/json" }
        };
    }
}
