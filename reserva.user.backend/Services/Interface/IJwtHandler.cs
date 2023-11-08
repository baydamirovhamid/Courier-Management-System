using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.HelperModels.Jwt;
using reserva.user.backend.Models;

namespace reserva.user.backend.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
    }
}
