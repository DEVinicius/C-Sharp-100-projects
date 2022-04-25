using _01_Learning_Core_Structure.Repository;

namespace _01_Learning_Core_Structure.Services;

public class BaseService
{
    private IUser userRespository;
    
    public BaseService(IUser _userRepository) {
        this.userRespository = _userRepository;
    }
}