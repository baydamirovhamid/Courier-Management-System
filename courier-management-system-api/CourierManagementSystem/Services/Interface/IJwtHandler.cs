using courier.management.system.DTO.HelperModels;
using courier.management.system.DTO.HelperModels.Jwt;
using courier.management.system.Models;

namespace courier.management.system.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
    }
}
