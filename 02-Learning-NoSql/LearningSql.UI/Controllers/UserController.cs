using Microsoft.AspNetCore.Mvc;

namespace LearningSql.UI.Controllers;

public class UserController : ControllerBase
{
    [HttpGet]
    [Route("/user")]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
    
    [HttpPost]
    [Route(("/user"))]
    public async Task<IActionResult> Create() {}
}