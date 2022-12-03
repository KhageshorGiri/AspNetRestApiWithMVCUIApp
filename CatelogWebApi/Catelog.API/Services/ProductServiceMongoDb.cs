using Catelog.API.Interfaces;
using Catelog.API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catelog.API.Services
{
    public class ProductServiceMongoDb : IProduct
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Product> itemsCollection;
        private readonly FilterDefinitionBuilder<Product> filterBuiulder = Builders<Product>.Filter;
        public ProductServiceMongoDb(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Product>(collectionName);
        }

        public async Task CreateProductAsync(Product product)
        {
            await itemsCollection.InsertOneAsync(product);
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            var products = await itemsCollection.FindAsync(_ => true);
            return products.ToList();
        }

        public async Task<Product?> GetProductAsync(Guid Id)
        {
            var filter = filterBuiulder.Eq(product => product.ProductID, Id);
            var products = itemsCollection.Find(filter);
            return await products.SingleOrDefaultAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var filter = filterBuiulder.Eq(product => product.ProductID, product.ProductID);
            await itemsCollection.ReplaceOneAsync(filter, product);
        }   

        public async Task DeleteProductAsync(Guid Id)
        {
            var filter = filterBuiulder.Eq(product => product.ProductID, Id);
            await itemsCollection.DeleteOneAsync(filter);
        }

       
    }
}
