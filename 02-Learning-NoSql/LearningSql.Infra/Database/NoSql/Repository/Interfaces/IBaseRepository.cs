using LearningSql.Domain.Entities;
using MongoDB.Bson;

namespace LearningSql.Infra.Database.NoSql.Repository.Interfaces;

public interface IBaseRepository<T> where T:Base
{
    Task<T> Create(T obj);
    Task<bool> Update(ObjectId id, T obj);
    Task<T?> Get(ObjectId id);
    Task<List<T>> Get();
    Task Delete(ObjectId id);
}