using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.HelperModels.Jwt;
using billkill.payment.service.Models;

namespace billkill.payment.service.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(UserClaims claims);
    }
}
