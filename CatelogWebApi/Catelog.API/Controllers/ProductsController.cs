using Catelog.API.Dtos.ProductDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catelog.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {       
        private readonly IProduct productService;
        public ProductsController(IProduct product)
        {
            this.productService = product;
        }

      
        // GET /products
        [HttpGet]
        public async Task<IEnumerable<ProductDto?>> GetProductsAsync()
        {
            var products = (await productService.GetProductsAsync()).Select(productItem => productItem?.AsDtos());

            return products;        
        }

        //GET /products/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDto?>> GetProductAsync(Guid Id)
        {
            var singleProduct = await productService.GetProductAsync(Id);
            if(singleProduct == null)
            {
                return NotFound();
            }
            return singleProduct.AsDtos();
        }

        //POST /products
        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            Product product = new()
            {
                ProductID = Guid.NewGuid(),
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                ProductPrice = createProductDto.ProductPrice,
                CreatedDate = DateTime.UtcNow,
            };
            await productService.CreateProductAsync(product);
            return NoContent();
        }

        //PUT /products/{id}
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateProductAsync(Guid Id, UpdateProductDto updateProductDto)
        {
            var existingProduct = productService.GetProductAsync(Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            Product product = new()
            {
                ProductName = updateProductDto.ProductName,
                ProductDescription= updateProductDto.ProductDescription,
                ProductPrice= updateProductDto.ProductPrice,
                UpdatedDate = DateTime.UtcNow,
            };
            await productService.UpdateProductAsync(product);
            return NoContent();
        }

        //DELETE /products/{id}
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProductAsync(Guid Id)
        {
            var existingProduct= productService.GetProductAsync(Id);
            if(existingProduct == null)
            {
                return NotFound();
            }
            await productService.DeleteProductAsync(Id);
            return NoContent();
        }
    }
}
