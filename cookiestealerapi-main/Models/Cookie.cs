using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cookie
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("cookies")]
    public string Cookies { get; set; }
    
    [BsonElement("metadata")]
    public abcd Metadata { get; set; }
    
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}