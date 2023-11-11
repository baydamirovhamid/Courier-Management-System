using reserva.user.backend.DTO.HelperModels.Jwt;
using reserva.user.backend.DTO.RequestModels.Auth;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
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
