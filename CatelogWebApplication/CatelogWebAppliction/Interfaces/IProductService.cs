using CatelogWebAppliction.Models;

namespace CatelogWebAppliction.Interfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(Product product);
        Task<List<Product?>> GetProductsAsync();

        Task<Product?> GetProductAsync(int id);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}
