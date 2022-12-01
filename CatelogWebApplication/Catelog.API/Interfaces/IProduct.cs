using Catelog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catelog.API.Interfaces
{
    public interface IProduct
    {
        public IEnumerable<Product?> GetProducts();

        public Product? GetProduct(Guid Id);

        void CreateProduct(Product product);

        void UpdateProduct(Guid Id, Product product);

        void DeleteProduct(Guid Id);
    }
}
