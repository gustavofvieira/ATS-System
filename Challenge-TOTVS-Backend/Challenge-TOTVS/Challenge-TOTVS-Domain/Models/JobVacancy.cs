using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Challenge.TOTVS.Domain.Models
{
    public class JobVacancy
    {
        [BsonElement("Description")]
        [JsonPropertyName("Descricao")]
        public string Description { get; set; } = default!;

        [BsonElement("StartDate")]
        [JsonPropertyName("DataInicial")]
        public DateTime StartDate { get; set; }
    }
}
