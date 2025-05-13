using BackendAspNet.core.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.core.utils;


public class GenericResponseController : ControllerBase
{
    public async Task<IActionResult> Handler(ApiResponse response)
    {
        if (!response.Success)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
}