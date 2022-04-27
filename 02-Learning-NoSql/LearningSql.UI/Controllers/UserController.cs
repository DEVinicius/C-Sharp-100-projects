using LearningSql.Application.Services.User;
using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearningSql.UI.Controllers;

public class UserController : ControllerBase
{
    [HttpGet]
    [Route("/user")]
    public async Task<IActionResult> Get()
    {
        return Ok("TSTE");
    }

    [HttpPost]
    [Route(("/user"))]
    public async Task<IActionResult> Create(
        [FromServices] IUserRepository userRepository,
        [FromBody] User user
    )
    {
        var createUserService = new CreateUserService(userRepository);

        var userCreated = await createUserService.Execute(user);

        return Ok(userCreated);
    }
}