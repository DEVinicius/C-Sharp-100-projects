using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.DTO;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;

namespace _01_Learning_Core_Structure.Services {
    public class CreateUserService {
        private IUser userRepository;

        public CreateUserService(IUser _userRepository) {
            this.userRepository = _userRepository;
        }

        public async Task<User> execute(UserDTO userDTO) {
            this.ensureEmailExists(userDTO.Email);

            return await this.createUser(userDTO);
        }

        private void ensureEmailExists(string email) {
            Task<User?> verifyUserExists = this.userRepository.findByEmail(email);

            if(verifyUserExists.Result != null) {
                throw new System.Exception("Email já inserido no sistema");
            }
        }

        private async Task<User> createUser(UserDTO userDTO) {
            User user = await this.userRepository.create(userDTO);

            return user;
        }
    }
}