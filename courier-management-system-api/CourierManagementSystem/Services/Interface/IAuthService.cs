using courier.management.system.DTO.HelperModels.Jwt;
using courier.management.system.DTO.RequestModels.Auth;
using courier.management.system.DTO.ResponseModels.Main;

namespace courier.management.system.Services.Interface
{
    public interface IAuthService
    {
        Task<ResponseSimple> RegisterUserAsync(ResponseSimple response, RegisterDto model);
        Task<ResponseObject<JwtResponse>> LoginAsync(ResponseObject<JwtResponse> response, LoginDto model);
        Task<ResponseSimple> ForgotPasswordAsync(ResponseSimple response, string email);
        Task<ResponseSimple> ResetPasswordAsync(ResponseSimple response, ResetPasswordDto model);
        Task<ResponseSimple> ChangePasswordAsync(ResponseSimple response, ChangePasswordDto model);
        //Task<ResponseSimple> ChangePasswordAsync(ResponseSimple response, ChangePasswordDto model);
    }
}
