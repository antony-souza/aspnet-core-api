using BackendAspNet.modules.user.dto;
using BackendAspNet.modules.user.usecase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.user;

[Authorize]
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUserUseCase;

    public UserController(CreateUserUseCase createUserUseCase)
    {
        _createUserUseCase = createUserUseCase;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
    {
        var response = await _createUserUseCase.Handler(createUserDto);

        return Ok(response);
    }
}