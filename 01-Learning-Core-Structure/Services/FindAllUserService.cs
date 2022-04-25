using _01_Learning_Core_Structure.Infra.Database.Model;
using _01_Learning_Core_Structure.Repository;

namespace _01_Learning_Core_Structure.Services;

public class FindAllUserService
{
    private readonly  IUser _userRepository;

    public FindAllUserService(IUser userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<List<User>> Execute()
    {
        return await this._userRepository.FindAll();
    }
}