using LearningSql.Domain.Entities;
using LearningSql.Infra.Database.NoSql.Repository.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LearningSql.Infra.Database.NoSql.Repository.Implementation;

public class BaseRepository<T> : IBaseRepository<T> where T:Base
{
    protected readonly IMongoDatabase _mongoDatabase;
    protected IMongoCollection<T> _collection;

    public BaseRepository(IMongoClient client)
    {
        this._mongoDatabase = client.GetDatabase("ManagerDb");
    }

    public virtual async Task<T> Create(T obj)
    {
        await _collection.InsertOneAsync(obj);

        return obj;
    }

    public virtual async Task<bool> Update(string id, T obj)
    {
        obj.Id = id;

        var result = await this._collection.ReplaceOneAsync(x => x.Id == id, obj);

        return result.ModifiedCount == 1;
    }

    public virtual Task<T?> Get(string id)
    {
        var filter = Builders<T>.Filter.Eq(c => c.Id, id);
        var data = _collection.Find(filter).FirstOrDefaultAsync();

        return data;
    }

    public virtual async Task<List<T>> Get()
    {
        return await this._collection.Find(_ => true).ToListAsync();
    }

    public virtual async Task Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq(c => c.Id, id);
        var result = await _collection.DeleteOneAsync(filter);
    }
}