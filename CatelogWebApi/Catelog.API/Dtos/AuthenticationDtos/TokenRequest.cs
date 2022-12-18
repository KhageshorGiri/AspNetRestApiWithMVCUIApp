namespace Catelog.API.Dtos.AuthenticationDtos
{
    public class TokenRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
