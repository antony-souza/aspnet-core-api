using BackendAspNet.modules.user.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.user;

[Authorize]
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly UserServices _userServices;

    public UserController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
    {
        var response = await _userServices.CreateUser(createUserDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("all-users")]
    public async Task<IActionResult> FindAllUsers()
    {
        var response = await _userServices.FindAllUsers();

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet]
    [Route("find-by-id/{id:guid}")]
    public async Task<IActionResult> FindUserById([FromRoute] string id)
    {
        var response = await _userServices.FindUserById(id);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}