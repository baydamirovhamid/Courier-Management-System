using billkill.manager.backend.DTO.HelperModels.Jwt;
using billkill.manager.backend.DTO.RequestModels;
using billkill.manager.backend.DTO.ResponseModels.Main;

namespace billkill.manager.backend.Services.Interface
{
    public interface IAuthService
    {
        Task<ResponseSimple> RegisterUserAsync(ResponseSimple response, RegisterUserDto model);
        Task<ResponseSimple> RegisterEmployeeAsync(ResponseSimple response, RegisterEmployeeDto model);
        Task<ResponseObject<JwtResponse>> LoginUserAsync(ResponseObject<JwtResponse> response, LoginDto model);
        Task<ResponseSimple> ForgotPasswordAsync(ResponseSimple response, string email);
        Task<ResponseSimple> ResetPasswordAsync(ResponseSimple response, ResetPasswordDto model);
        //Task<ResponseSimple> RegisterEmployeeAsync(ResponseSimple response, UserDto model);
    }
}
