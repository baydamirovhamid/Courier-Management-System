using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.HelperModels.Jwt;
using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.DTO.ResponseModels.Main;

namespace billkill.payment.service.Services.Interface
{
    public interface IAuthService
    {
        ResponseObject<JwtResponse> GenerateToken(ResponseObject<JwtResponse> response, UserClaims model);
 
    }
}
