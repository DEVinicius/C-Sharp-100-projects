using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningSql.Domain.Entities;

public class Base
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    private DateTime CreatedAt { get; set; }

    protected Base()
    {
        this.CreatedAt = DateTime.Now;
    }
}