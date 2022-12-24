using CatelogWebAppliction.Models;

namespace CatelogWebAppliction.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(User user);
        Task LoginAsync(User user);
    }
}
