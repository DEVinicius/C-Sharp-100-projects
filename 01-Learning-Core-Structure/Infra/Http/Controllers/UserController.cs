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
        public async Task<IActionResult> CreateUser([FromServices] IUser _userRepository,UserDTO userDTO) {
                var createUserService = new CreateUserService(_userRepository);

                User userCreated = await createUserService.execute(userDTO);

                return Ok(userCreated);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IUser _userRepository) {
            return Ok(new List<User>());
        }
    }
}