using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class UpdateUserService
{
    private IUserRepository _userRepository;

    public UpdateUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<bool> Execute(string id, Domain.Entities.User user)
    {
        await this.EnsureUserExists(id);

        return await this._userRepository.Update(id, user);
    }
    
    private async Task EnsureUserExists(string id)
    {
        var verifyEmailAlreadyExists = await this._userRepository.Get(id);

        if (verifyEmailAlreadyExists == null)
        {
            throw new System.Exception("Usuário não existente");
        }
    }
}