using billkill.manager.backend.DTO.HelperModels.Jwt;
using billkill.manager.backend.Models;

namespace billkill.manager.backend.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(USER claims);
    }
}
