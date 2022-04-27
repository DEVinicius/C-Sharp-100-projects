using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using MongoDB.Driver;

namespace LearningSql.Infra.Database.NoSql.Repository.Implementation;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public Task<User> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public UserRepository(IMongoClient client) : base(client)
    {
    }
}