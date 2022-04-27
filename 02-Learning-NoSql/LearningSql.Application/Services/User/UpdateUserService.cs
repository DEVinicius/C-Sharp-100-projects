using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class UpdateUserService
{
    private IUserRepository _userRepository;

    public UpdateUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }
    
    public async Task Execute(){}
}