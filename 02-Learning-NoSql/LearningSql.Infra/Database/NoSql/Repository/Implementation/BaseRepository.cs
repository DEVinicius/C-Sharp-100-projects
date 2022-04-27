using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LearningSql.Infra.Database.NoSql.Repository.Implementation;

public class BaseRepository<T> : IBaseRepository<T> where T:Base
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<T> _collection;

    public BaseRepository(IMongoClient client)
    {
        this._mongoDatabase = client.GetDatabase("ManagerDb");
        this._collection = this._mongoDatabase.GetCollection<T>(nameof(T));
    }

    public virtual async Task<T> Create(T obj)
    {
        await _collection.InsertOneAsync(obj);

        return obj;
    }

    public virtual async Task<bool> Update(ObjectId id, T obj)
    {
        var filter = Builders<T>.Filter.Eq(c => c.Id, id);
        var update = Builders<T>.Update
            .Set(c => c, obj);
        var result = await _collection.UpdateOneAsync(filter, update);

        return result.ModifiedCount == 1;
    }

    public virtual Task<T?> Get(ObjectId id)
    {
        var filter = Builders<T>.Filter.Eq(c => c.Id, id);
        var data = _collection.Find(filter).FirstOrDefaultAsync();

        return data;
    }

    public virtual async Task<List<T>> Get()
    {
        return await this._collection.Find(_ => true).ToListAsync();
    }

    public virtual async Task Delete(ObjectId id)
    {
        var filter = Builders<T>.Filter.Eq(c => c.Id, id);
        var result = await _collection.DeleteOneAsync(filter);
    }
}