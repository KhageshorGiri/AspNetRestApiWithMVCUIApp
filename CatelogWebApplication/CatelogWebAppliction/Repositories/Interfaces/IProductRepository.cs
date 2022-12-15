using CatelogWebAppliction.Models;

namespace CatelogWebAppliction.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);
        Task<List<Product?>> GetProductsAsync();

        Task<Product?> GetProductAsync(int id);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}
