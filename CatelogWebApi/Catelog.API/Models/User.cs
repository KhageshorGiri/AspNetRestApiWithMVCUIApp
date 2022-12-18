
using MongoDB.Bson.Serialization.Attributes;

namespace Catelog.API.Models
{
    public class User
    {
        [BsonId]
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }  
        public bool IsConfirmed { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
    }
}
