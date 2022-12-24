using CatelogWebAppliction.Models;

namespace CatelogWebAppliction.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);
        Task LoginAsync(User user);
    }
}
