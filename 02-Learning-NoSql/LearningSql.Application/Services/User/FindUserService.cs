using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class FindUserService
{
    private IUserRepository _userRepository;

    public FindUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }
    
    public async Task Execute(){}

}