using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class DeleteUserService
{
    private IUserRepository _userRepository;

    public DeleteUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task Execute(string id)
    {
        await this._userRepository.Delete(id);
    }

}