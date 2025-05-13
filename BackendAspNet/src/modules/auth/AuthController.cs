using BackendAspNet.core.utils;
using BackendAspNet.modules.auth.dto;
using Microsoft.AspNetCore.Mvc;
namespace BackendAspNet.modules.auth;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    
    public AuthController(AuthService authUseCase)
    {
        _authService = authUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] AuthDto authDto)
    {
       var response = await _authService.Handler(authDto);
       return GenericResponseController.Handler(response);
    }
}