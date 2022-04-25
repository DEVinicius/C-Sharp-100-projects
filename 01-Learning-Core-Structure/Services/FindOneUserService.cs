using _01_Learning_Core_Structure.Infra.Database.Model;
using _01_Learning_Core_Structure.Repository;

namespace _01_Learning_Core_Structure.Services;

public class FindOneUserService
{
    private readonly  IUser _userRepository;
    
    public FindOneUserService(IUser userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<User?> Execute(long id)
    {
        return await this._userRepository.FindById(id);
    }
}