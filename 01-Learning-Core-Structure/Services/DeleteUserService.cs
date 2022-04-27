using _01_Learning_Core_Structure.Repository;

namespace _01_Learning_Core_Structure.Services;

public class DeleteUserService
{
    private readonly IUser _userRepository;

    public DeleteUserService(IUser userRepository)
    {
        this._userRepository = userRepository;
    }

    public void Execute(long id)
    {
        this._userRepository.Delete(id);
    }
}