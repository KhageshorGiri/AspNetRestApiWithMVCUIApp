using Catelog.API.Interfaces;
using Catelog.API.Models;
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
        public IEnumerable<Product?> GetProducts()
        {
            return productService.GetProducts();
        }

        //GET /products/{id}
        [HttpGet("{Id}")]
        public ActionResult<Product?> GetProduct(Guid Id)
        {
            Product? singleProduct = productService.GetProduct(Id);
            if(singleProduct == null)
            {
                return NotFound();
            }
            return singleProduct;
        }

        //POST /products
        [HttpPost]
        public void CreateProduct(Product product)
        {
            productService.CreateProduct(product);
        }

        //PUT /products/{id}
        [HttpPut("{Id}")]
        public ActionResult UpdateProduct(Guid Id, Product product)
        {
            Product? existingProduct = productService.GetProduct(Id);


            if (existingProduct == null)
            {
                return NotFound();
            }
            productService.UpdateProduct(Id, product);
            return NoContent();
        }

        //DELETE /products/{id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteProduct(Guid Id)
        {
            Product? existingProduct= productService.GetProduct(Id);
            if(existingProduct == null)
            {
                return NotFound();
            }
            productService.DeleteProduct(Id);
            return NoContent();
        }
    }
}
