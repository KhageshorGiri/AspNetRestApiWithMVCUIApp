using CatelogWebAppliction.Interfaces;
using CatelogWebAppliction.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatelogWebAppliction.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productsList = await productService.GetProductsAsync();
            return View(productsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await productService.CreateProductAsync(product);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var product = await productService.GetProductAsync(Id);
            if(product == null)
            {
                return NoContent();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Product product)
        {
            var existingProduct = await productService.GetProductAsync(Id);
            if(existingProduct == null)
            {
                return NoContent();
            }
            Product updatedProduct = new()
            {
                productName = product.productName,
                productDescription = product.productDescription,
                productPrice = product.productPrice,              
            };
            await productService.UpdateProductAsync(updatedProduct);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var existingProduct = await productService.GetProductAsync(Id);
            if (existingProduct == null)
            {
                return NoContent();
            }
            await productService.DeleteProductAsync(Id);
            return View();
        }
    }
}
