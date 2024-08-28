using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Responses;

namespace OnlineShop.Presentation.Extensions;

public static class ValidationErrorHandlerExtension
{
    public static ObjectResult HandleValidationErrors(this ActionContext context)
    {
        var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e =>
                    {
                        var message = e.ErrorMessage.ToLowerInvariant();
                        return message.Substring(0, 1).ToUpper() + message.Substring(1);
                    })
                    .ToList();

        var response = new ValidationErrorResponse(errors);

        return new BadRequestObjectResult(response)
        {
            ContentTypes = { "application/json" }
        };
    }
}
