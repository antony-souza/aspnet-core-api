using BackendAspNet.core.utils;
using BackendAspNet.modules.user.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.user;

// [Authorize]
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
        return GenericResponseController.Handler(response);
    }

    [HttpGet]
    [Route("all-users")]
    public async Task<IActionResult> FindAllUsers()
    {
        var response = await _userServices.FindAllUsers();
        return GenericResponseController.Handler(response);
    }
    
    [HttpGet]
    [Route("find-by-id/{id:guid}")]
    public async Task<IActionResult> FindUserById([FromRoute] string id)
    {
        var response = await _userServices.FindUserById(id);
        return GenericResponseController.Handler(response);
    }
    
    [HttpPut]
    [Route("update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] string id,[FromBody] UpdateUserDto updateUserDto)
    {
        var response = await _userServices.UpdateUser(id ,updateUserDto);
        return GenericResponseController.Handler(response);
    }
    
    [HttpPut]
    [Route("delete/{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] string id)
    {
        var response = await _userServices.DeleteUser(id);
        return GenericResponseController.Handler(response);
    }
}