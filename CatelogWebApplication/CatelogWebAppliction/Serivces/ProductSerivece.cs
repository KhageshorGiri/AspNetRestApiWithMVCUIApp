

using CatelogWebAppliction.Interfaces;
using CatelogWebAppliction.Models;
using CatelogWebAppliction.Repositories.Interfaces;

namespace CatelogWebAppliction.Serivces
{
    public class ProductSerivece : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductSerivece(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }
        public async Task CreateProductAsync(Product product)
        {
            await _repository.CreateProductAsync(product);
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);
            return product;
        }

        public async Task<List<Product?>> GetProductsAsync()
        {
            var productsList = await _repository.GetProductsAsync();
            return productsList;
        }
        
        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }

    }
}
