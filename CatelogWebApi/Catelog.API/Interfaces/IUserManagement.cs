using Catelog.API.Dtos.AuthenticationDtos;
using Catelog.API.Dtos.UserDtos;
using Catelog.API.Models;

namespace Catelog.API.Interfaces
{
    public interface IUserManagement
    {
        Task CreateUserAsync(User user);

        Task<User?> GetUserByEmailAsync(TokenRequest tokenRequest);

    }
}
