using BackendAspNet.modules.user.schema;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.user;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] UserSchema userSchema)
    {
        
        return Ok();
    }
}