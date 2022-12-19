

using Catelog.API.Dtos.AuthenticationDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Catelog.API.Services
{
    public class AuthenticationService : IAuthentication
    {
        private const string databaseName = "catalog";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuiulder = Builders<User>.Filter;

        // refrence to the usermanagement service
        private readonly IUserManagement _userManagementService;
        public AuthenticationService(IMongoClient mongoClient, IUserManagement userManagement)
        {
            // creating a database if not exist.
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);

            this._userManagementService = userManagement;
        }
        
        public async Task<TokenResponse> LoginUserAsync(TokenRequest tokenRequest)
        {
            var user = await _userManagementService.GetUserByEmailAsync(tokenRequest);
            if(user != null)
            {
                return CreateJwtToke(user);
            }
            throw new AuthenticationException();
        }

        // function to create a JWT token
        private TokenResponse CreateJwtToke(User user)
        {
            var claimsList = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };


            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisisSecretXKeyThaGeneratETheJWTTokenishdgihsuihiwhj"));
            var creds = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "",
                audience: "",
                claims: claimsList,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var tokenResponse = new TokenResponse()
            {
                Token = jwtToken,
                RefreshToken = ""
            };

            return tokenResponse;
        }

    }
}
