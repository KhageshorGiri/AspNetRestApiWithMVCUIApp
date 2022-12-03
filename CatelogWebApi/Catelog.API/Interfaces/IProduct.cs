using Catelog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catelog.API.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product?>> GetProductsAsync();

        Task<Product?> GetProductAsync(Guid Id);

        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(Guid Id);
    }
}
