

using System.ComponentModel.DataAnnotations;




namespace Catelog.API.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Product Name Cannot be NUll Value.")]
        [StringLength(2000, ErrorMessage = "Product name should be less then 2000 characters.")]
        public string? ProductName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Production Description Cannot be null value.")]
        [StringLength(5000, ErrorMessage = "Product Description should be less then 5000 characters.")]
        public string? ProductDescription { get; set; } = String.Empty;

        [Required(ErrorMessage = "Product Price Cannot be Empty.")]
        [Range(0, 9999999999999999, ErrorMessage = "Product price show be in range 0 to 9999999999999999999")]
        public decimal ProductPrice { get; set; } = 0;
    }
}
