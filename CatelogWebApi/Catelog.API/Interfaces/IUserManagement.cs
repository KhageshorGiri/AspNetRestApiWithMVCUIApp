using Catelog.API.Dtos.UserDtos;
using Catelog.API.Models;

namespace Catelog.API.Interfaces
{
    public interface IUserManagement
    {
        Task CreateUserAsync(User user);
        
    }
}
