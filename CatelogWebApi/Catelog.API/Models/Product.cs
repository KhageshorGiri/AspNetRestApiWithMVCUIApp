using MongoDB.Bson.Serialization.Attributes;

namespace Catelog.API.Models
{
    public class Product
    {
        [BsonId]
        public Guid ProductID { get; set; } = Guid.NewGuid();
        public string? ProductName { get; set; } = String.Empty;
        public string? ProductDescription { get; set; } = String.Empty;
        public decimal ProductPrice { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } 
    }
}
