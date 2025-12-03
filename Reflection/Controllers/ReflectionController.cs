using General.Replaces;
using Microsoft.AspNetCore.Mvc;

namespace Reflection.Controllers;

[ApiController]
[Route("[controller]")]
public class ReflectionController : ControllerBase
{
    [HttpGet("available-keys")]
    public IActionResult GetTemplateKeys()
    {
        return Ok(PropertyCache<EventExample>.AvailableKeys);
    }
}
