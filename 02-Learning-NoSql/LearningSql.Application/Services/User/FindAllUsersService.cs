using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class FindAllUsersService
{
    private IUserRepository _userRepository;

    public FindAllUsersService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<List<Domain.Entities.User>> Execute()
    {
        return await this._userRepository.Get();
    }
}