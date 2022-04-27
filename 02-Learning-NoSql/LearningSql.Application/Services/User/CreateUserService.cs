using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class CreateUserService
{
    private IUserRepository _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task Execute()
    {

    }
}