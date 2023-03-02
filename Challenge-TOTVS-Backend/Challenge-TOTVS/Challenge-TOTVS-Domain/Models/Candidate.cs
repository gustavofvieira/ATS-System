using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Domain.Models
{
    public class Candidate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; } = default!;

        [BsonElement("Name")]
        [JsonPropertyName("Nome")]
        public string Name { get; set; } = default!;

        [BsonElement("Birthday")]
        [JsonPropertyName("DataNascimento")]
        public DateTime Birthday { get; set; }
    }
}
