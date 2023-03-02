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

        [BsonElement("Login")]
        [JsonPropertyName("Login")]
        public string Login { get; set; } = default!;

        [BsonElement("Password")]
        [JsonPropertyName("Senha")]
        public string Password { get; set; } = default!;

        [BsonElement("Name")]
        [JsonPropertyName("Nome")]
        public string Name { get; set; } = default!;

        [BsonElement("Birthday")]
        [JsonPropertyName("DataNascimento")]
        public DateTime Birthday { get; set; }

        //[BsonElement("File")]
        //public IFormFile File { get; set; }= default!;


    }
}
