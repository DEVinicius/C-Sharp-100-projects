using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningSql.Domain.Entities;

public class Base
{
    [BsonId]
    public ObjectId Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public Base()
    {
        this.CreatedAt = DateTime.Now;
    }
}