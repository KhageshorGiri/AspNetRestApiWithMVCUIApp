using Catelog.API.Dtos.AuthenticationDtos;
using Catelog.API.Models;

namespace Catelog.API.Interfaces
{
    public interface IAuthentication
    {
        
        Task<TokenResponse> LoginUserAsync(TokenRequest tokenRequest);
    }
}
