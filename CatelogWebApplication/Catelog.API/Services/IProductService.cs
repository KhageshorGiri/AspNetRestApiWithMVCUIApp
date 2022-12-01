using Catelog.API.Interfaces;
using Catelog.API.Models;

namespace Catelog.API.Services
{
    public class IProductService : IProduct
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { ProductID = Guid.NewGuid(), ProductName = "Product 1", ProductPrice = 100, ProductDescription = "First product in stock", CreatedDate = DateTime.UtcNow },
            new Product { ProductID = Guid.NewGuid(), ProductName = "Product 2", ProductPrice = 200, ProductDescription = "Second product in stock", CreatedDate = DateTime.UtcNow },
            new Product { ProductID = Guid.NewGuid(), ProductName = "Product 3", ProductPrice = 350, ProductDescription = "Third product in stock", CreatedDate = DateTime.UtcNow }
        };

            
        public IEnumerable<Product?> GetProducts()
        {
            return products;
        }

        public Product? GetProduct(Guid Id)
        {
            Product? singleProduct = products.SingleOrDefault(product => product.ProductID == Id);
            return singleProduct;
        }
        public void CreateProduct(Product product)
        {
            product.ProductID = Guid.NewGuid();
            products.Add(product);
        }
        public void UpdateProduct(Guid Id, Product product)
        {
            int itemIndex = products.FindIndex(product => product.ProductID == Id);
            products[itemIndex] = product;
        }

        public void DeleteProduct(Guid Id)
        {
            int itemIndex = products.FindIndex(product => product.ProductID == Id);
            products.RemoveAt(itemIndex);
        }


    }
}
