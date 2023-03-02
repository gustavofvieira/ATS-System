using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Domain.Models
{
    public class JobApplication
    {
        [BsonId]
        public Guid JobApplicationId { get; set; }
        public Guid CadidateId { get; set; }
        public Guid JobVacancyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
