using Microsoft.AspNetCore.Mvc;

namespace Order.Dispatch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("OrderDispatchService is running");
}
