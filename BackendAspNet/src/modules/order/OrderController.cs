using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNet.modules.order;

[Authorize]
[Route("order")]
public class OrderController : ControllerBase
{
    
}