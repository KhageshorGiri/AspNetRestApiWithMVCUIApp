namespace Catelog.API.Dtos.AuthenticationDtos
{
    public class TokenResponse
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
