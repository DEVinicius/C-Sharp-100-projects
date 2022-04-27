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
    
    public override async Task<bool> Update(string id, User obj)
    {
        obj.Id = id;

        var actualUser = await this.Get(id);

        if (obj.Email == null)
        {
            obj.Email = actualUser.Email;
        }
        
        if (obj.Name == null)
        {
            obj.Name = actualUser.Name;
        }

        var result = await this._collection.ReplaceOneAsync(x => x.Id == id, obj);

        return result.ModifiedCount == 1;
    }

    public UserRepository(IMongoClient client) : base(client)
    {
        this._collection = this._mongoDatabase.GetCollection<User>(nameof(User));
    }
}