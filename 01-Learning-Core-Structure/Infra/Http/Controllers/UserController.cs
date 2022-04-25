using Microsoft.AspNetCore.Mvc;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;
using _01_Learning_Core_Structure.Infra.Database.DTO;
using _01_Learning_Core_Structure.Services;
using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Repository.Implementation;

namespace _01_Learning_Core_Structure.Infra.Http.Controllers {
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromServices] IUser userRepository,UserDTO userDto) {
                var createUserService = new CreateUserService(userRepository);

                var userCreated = await createUserService.Execute(userDto);

                return Ok(userCreated);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IUser userRepository)
        {
            var findAllUserService = new FindAllUserService(userRepository);
            return Ok( await findAllUserService.Execute());
        }

        [HttpGet]
        [Route("/user/{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IUser userRepository,
            [FromRoute] long id
        )
        {
            var findOneUserService = new FindOneUserService(userRepository);

            var user = await findOneUserService.Execute(id);

            return Ok(user);
        }
    }
}