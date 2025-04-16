using BackendAspNet.modules.user.dto;
using BackendAspNet.modules.user.usecase;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.user;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private CreateUserUseCase _createUserUseCase;

    public UserController(CreateUserUseCase createUserUseCase)
    {
        _createUserUseCase = createUserUseCase;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] UserDto userDto)
    {
        var response = await _createUserUseCase.Handler(userDto);

        return Ok(response);
    }
}