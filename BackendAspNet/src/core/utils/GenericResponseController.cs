using BackendAspNet.core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.core.utils;

public class GenericResponseController : ControllerBase
{
    public static IActionResult Handler(ApiResponse response)
    {
        return response.Success ? new OkObjectResult(response) : new BadRequestObjectResult(response);
    }
}