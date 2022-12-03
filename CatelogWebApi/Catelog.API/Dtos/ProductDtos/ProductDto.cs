




namespace Catelog.API.Dtos.ProductDtos
{
    public class ProductDto
    {
        public Guid ProductID { get; set; } = Guid.NewGuid();
        public string? ProductName { get; set; } = String.Empty;
        public string? ProductDescription { get; set; } = String.Empty;
        public decimal ProductPrice { get; set; } = 0;
    }
}
