using LearningSql.Application.Services.User;
using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LearningSql.UI.Controllers;

public class UserController : ControllerBase
{
    [HttpGet]
    [Route("/user")]
    public async Task<IActionResult> Get([FromServices] IUserRepository userRepository) =>
        (Ok(await (new FindAllUsersService(userRepository)).Execute()));

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

    [HttpGet]
    [Route("/user/{id}")]
    public async Task<IActionResult> GetOne(
        [FromServices] IUserRepository userRepository,
        [FromRoute] string id
    )
    {
        var findOneUserService = new FindUserService(userRepository);

        var user = await findOneUserService.Execute(id);
        
        return Ok(user);
    }

    [HttpPut]
    [Route("/user/{id}")]
    public async Task<IActionResult> Update(
        [FromServices] IUserRepository userRepository,
        [FromRoute] string id,
        [FromBody] User user
    )
    {
        var updateUserService = new UpdateUserService(userRepository);

        var isUserUpdated = await updateUserService.Execute(id, user);

        return Ok(isUserUpdated);
    }

    [HttpDelete]
    [Route("/user/{id}")]
    public async Task Delete(
        [FromServices] IUserRepository userRepository,
        [FromRoute] string id
    )
    {
        var deleteUserService = new DeleteUserService(userRepository);

        await deleteUserService.Execute(id);
    }
}