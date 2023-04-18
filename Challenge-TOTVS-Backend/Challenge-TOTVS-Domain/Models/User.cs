using Challenge.TOTVS.Domain.Constants;
using Challenge.TOTVS.Domain.ViewModel;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;

namespace Challenge.TOTVS.Domain.Models
{
    public class User
    {
        [BsonId]
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }


        public static explicit operator User(CandidateVM candidateVM)
        {
            return new User
            {
                Name = candidateVM.Name,
                EmailAddress = candidateVM.EmailAddress,
                Password = candidateVM.Password,
                Role = Roles.Common

            };
        }
    }
}
