using AntiDotNET.Application.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace AntiDotNET.Presentation.WebFramework.Extensions;

public static class OperationResultExtension
{
    public static IActionResult ToActionResult<TResult>(this OperationResult<TResult> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Result);
        }

        if (result.IsNotFound)
        {
            return string.IsNullOrEmpty(result.Message) ? new OkResult() : new OkObjectResult(result.Message);
        }

        return string.IsNullOrEmpty(result.Message)
            ? new BadRequestObjectResult("Invalid Parameters. Please try again")
            : new BadRequestObjectResult(result.Message);
    }
}