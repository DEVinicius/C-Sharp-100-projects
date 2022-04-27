using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using MongoDB.Bson;

namespace LearningSql.Application.Services.User;

public class FindUserService
{
    private IUserRepository _userRepository;

    public FindUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<Domain.Entities.User?> Execute(string id)
    {
        return await this._userRepository.Get(id);
    }

}