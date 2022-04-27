using _01_Learning_Core_Structure.Infra.Database.Model;
using _01_Learning_Core_Structure.Repository;

namespace _01_Learning_Core_Structure.Services;

public class UpdateUserService
{
    private readonly IUser _userRepository;

    public UpdateUserService(IUser userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<User> Execute(long id, User user);
    {
        this.EnsureUserExists(id);
        return await this.Update(id, user);
    }
    
    private void EnsureUserExists(long id) {
        var verifyUserExists = this._userRepository.FindById(id);

        if(verifyUserExists.Result != null) {
            throw new System.Exception("Email já inserido no sistema");
        }
    }

    private async Task<User?> Update(long id, User user)
    {
        return await this._userRepository.Update(id);
    }
}