using billkill.manager.backend.DTO.HelperModels.Jwt;

namespace billkill.manager.backend.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
    }
}
