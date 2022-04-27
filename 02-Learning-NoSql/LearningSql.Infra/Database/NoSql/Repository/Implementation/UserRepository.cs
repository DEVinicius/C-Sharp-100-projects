using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using MongoDB.Driver;

namespace LearningSql.Infra.Database.NoSql.Repository.Implementation;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public Task<User> GetByEmail(string email)
    {
        var filter = Builders<User>.Filter.Eq(c => c.Email, email);
        var data = _collection.Find(filter).FirstOrDefaultAsync();

        return data;
    }

    public UserRepository(IMongoClient client) : base(client)
    {
        this._collection = this._mongoDatabase.GetCollection<User>(nameof(User));
    }
}