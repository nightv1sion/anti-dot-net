using AntiDotNET.Application.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace AntiDotNET.Presentation.WebFramework.BaseController;

public abstract class BaseController : ControllerBase
{
    protected IActionResult OperationResult<TModel>(OperationResult<TModel> result)
    {
        if (result.IsSuccess)
        {
            return result.Result is null ? new OkResult() : new OkObjectResult(result.Result);
        }

        ModelState.AddModelError("General Error", result.Message);
        var validationProblemDetails = new ValidationProblemDetails(ModelState);
        
        if (result.IsNotFound)
        {
            return NotFound(validationProblemDetails.Errors);
        }
        
        return BadRequest(validationProblemDetails.Errors);
    }
}