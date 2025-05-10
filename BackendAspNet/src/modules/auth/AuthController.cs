using BackendAspNet.modules.auth.dto;
using BackendAspNet.modules.auth.usecase;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.auth;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthUseCase _authUseCase;
    
    public AuthController(AuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] AuthDto authDto)
    {
       var response = await _authUseCase.Handler(authDto);

       if (!response.Success)
       {
           return BadRequest(response);
       }

       return Ok(response);
    }
}