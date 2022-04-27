using LearningSql.Infra.Database.NoSql.Repository.Interfaces;

namespace LearningSql.Application.Services.User;

public class CreateUserService
{
    private readonly IUserRepository _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<Domain.Entities.User> Execute(Domain.Entities.User user)
    {
        await this.EnsureEmailAlreadyExists(user.Email);
        return await this._userRepository.Create(user);
    }

    private async Task EnsureEmailAlreadyExists(string email)
    {
        var verifyEmailAlreadyExists = await this._userRepository.GetByEmail(email);

        if (verifyEmailAlreadyExists != null)
        {
            throw new System.Exception("Email já inserido no sistema");
        }
    }
}