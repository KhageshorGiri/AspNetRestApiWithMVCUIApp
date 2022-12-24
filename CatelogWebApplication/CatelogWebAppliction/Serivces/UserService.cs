using CatelogWebAppliction.Interfaces;
using CatelogWebAppliction.Models;
using CatelogWebAppliction.Repositories.Interfaces;

namespace CatelogWebAppliction.Serivces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task LoginAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            var responseStatus = await _userRepository.RegisterUserAsync(user);
            return responseStatus;
        }
    }
}
