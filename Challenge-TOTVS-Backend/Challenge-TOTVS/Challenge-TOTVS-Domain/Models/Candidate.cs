using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Domain.Models
{
    public class Candidate
    {
        [BsonId]
        public Guid CandidateId { get; set; } 

        public string Login { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string Name { get; set; } = default!;

        public DateTime Birthday { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }

        //public IFormFile FormFile { get; set; } = default!;

        //public string FilePath { get; set; } = default!;


    }
}
