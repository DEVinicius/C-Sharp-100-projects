using LearningSql.Domain.Entities;

namespace LearningSql.Infra.Database.NoSql.Repository.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
}