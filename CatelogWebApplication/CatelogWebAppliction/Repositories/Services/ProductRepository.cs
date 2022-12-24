using CatelogWebAppliction.Models;
using CatelogWebAppliction.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CatelogWebAppliction.Repositories.Services
{
    public class ProductRepository : IProductRepository
    {
        static HttpClient httpClient = new HttpClient();
        private readonly string baseUrl = "https://localhost:7074";
        public Task CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product?>> GetProductsAsync()
        {
            string path = $"{baseUrl}/products";
            HttpResponseMessage response = await httpClient.GetAsync(path);

            List<Product?> productList = new List<Product?>();

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseData);
                productList = JsonSerializer.Deserialize<List<Product?>>(responseData);
            }
            
            return productList;
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
