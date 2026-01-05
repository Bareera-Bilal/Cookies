using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class abcd
{
   [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("url")]
    public string Url { get; set; } = null!;

    [BsonElement("referrer")]
    public string Referrer { get; set; } = null!;

    [BsonElement("userAgent")]
    public string UserAgent { get; set; } = null!;

    [BsonElement("timestamp")]
    public long Timestamp { get; set; }

    [BsonElement("origin")]
    public string Origin { get; set; } = null!;
}