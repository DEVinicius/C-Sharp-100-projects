using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.DTO;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;

namespace _01_Learning_Core_Structure.Services {
    public class CreateUserService {
        private readonly IUser _userRepository;

        public CreateUserService(IUser userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> Execute(UserDTO userDto) {
            this.EnsureEmailExists(userDto.Email);

            return await this.CreateUser(userDto);
        }

        private void EnsureEmailExists(string email) {
            var verifyUserExists = this._userRepository.FindByEmail(email);

            if(verifyUserExists.Result != null) {
                throw new System.Exception("Email já inserido no sistema");
            }
        }

        private async Task<User> CreateUser(User userDto) {
            var user = await this._userRepository.Create(userDto);

            return user;
        }
    }
}