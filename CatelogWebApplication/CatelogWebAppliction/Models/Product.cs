

namespace CatelogWebAppliction.Models
{
    public class Product
    {
        public Guid productID { get; set; } = Guid.NewGuid();
        public string? productName { get; set; } = String.Empty;
        public string? productDescription { get; set; } = String.Empty;
        public decimal productPrice { get; set; } = 0;
    }
}
