using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Domain.Models
{
    public class JobApplication
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; } = default!;
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [BsonElement("CadidateId")]
        public string CadidateId { get; set; } = default!;
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [BsonElement("JobVacancyId")]
        public string JobVacancyId { get; set; } = default!;
     
        [JsonIgnore]
        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
