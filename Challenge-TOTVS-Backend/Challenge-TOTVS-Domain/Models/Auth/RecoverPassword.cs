using MongoDB.Bson.Serialization.Attributes;

namespace Challenge.TOTVS.Domain.Models.Auth
{
    public class RecoverPassword
    {
        [BsonId]
        public Guid RecoverPasswordId { get; set; }
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpirateAt { get; set; } = DateTime.UtcNow.AddMinutes(5);
    }
}
