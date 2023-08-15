namespace billkill.manager.backend.DTO.HelperModels.Jwt
{
    public class JwtResponse
    {
        public string Token { get; set; }
        public long ExpiresAt { get; set; }
    }
}
