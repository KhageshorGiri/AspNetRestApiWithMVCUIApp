
using Catelog.API.Dtos.AuthenticationDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using MongoDB.Driver;
using System.Security.Authentication;

namespace Catelog.API.Services
{
    public class UserManagementService : IUserManagement
    {
        private const string databaseName = "catalog";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuiulder = Builders<User>.Filter;

        public UserManagementService(IMongoClient mongoClient)
        {
            // creating a database if not exist.
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }
      
        public async Task CreateUserAsync(User user)
        {
            await usersCollection.InsertOneAsync(user);
        }


        public async Task<User?> GetUserByEmailAsync(TokenRequest tokenRequest)
        {
            var userFilter = filterBuiulder.Eq(user => user.Email, tokenRequest.Email);
            var user = await (await usersCollection.FindAsync(userFilter)).SingleOrDefaultAsync();

            if (user == null)
            {
                throw new AuthenticationException();
            }
            if (user.Password != tokenRequest.Password)
            {
                throw new AuthenticationException();
            }

            return user;
        }

    }
}
