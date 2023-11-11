using AutoMapper;
using reserva.user.backend.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;
using reserva.user.backend.Models;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Extensions;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.DTO.RequestModels.Auth;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.HelperModels.Jwt;

namespace billkill.manager.backend.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<USER> _userManager;
        private readonly SignInManager<USER> _signInManager;
        private readonly ILoggerManager _logger;
        private readonly IRepository<CLIENT> _clients;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEmailService _emailService;
        AppConfiguration config = new AppConfiguration();

        public AuthService(
            UserManager<USER> userManager,
            SignInManager<USER> signInManager,
            ILoggerManager logger,
            IRepository<CLIENT> clients,
            IMapper mapper,
            IJwtHandler jwtHandler,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _clients = clients;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _emailService = emailService;
        }

        public async Task<ResponseSimple> RegisterUserAsync(ResponseSimple response, RegisterDto model)
        {
            try
            {
                var user = _mapper.Map<USER>(model);

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "Problem baş verdi!";
                }
                else
                    response.Status.Message = "Uğurla əlavə olundu!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(RegisterUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseObject<JwtResponse>> LoginAsync(ResponseObject<JwtResponse> response, LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.UserName);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(model.UserName);
                    if(user == null)
                    {
                        response.Status.ErrorCode = ErrorCodes.AUTH;
                        response.Status.Message = "İstifadəçi adı və ya şifrə yanlışdır!";
                        return response;
                    }
                  
                }
              
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "İstifadəçi adı və ya şifrə yanlışdır!";
                    return response;
                }
                if (!(await _signInManager.CanSignInAsync(user)))
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Daxil olmaq mümkün olmadı!";
                    return response;
                }
                var claims = _mapper.Map<JwtCustomClaims>(user);
                response.Response = _jwtHandler.CreateToken(claims);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> ForgotPasswordAsync(ResponseSimple response, string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    response.Status.Message = "Belə bir user tapılmadı!";
                    return response;
                }

                var token = await GeneratePasswordResetTokenAsync(user);
                token = HttpUtility.UrlEncode(token);
                var link = config.MailUrl + $"reset-password?token={token}&email={email}";
                _emailService.SendEmailForgetPassword(email, link);
                response.Status.Message = "Şifrəni yeniləmək üçün emailinizə link göndərildi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> ResetPasswordAsync(ResponseSimple response, ResetPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    response.Status.Message = "Belə bir user tapılmadı!";
                    return response;
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (!result.Succeeded)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Şifrə yenilənmədi!";
                    return response;
                }

                response.Status.Message = "Şifrə yeniləndi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ResetPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }


        public async Task<ResponseSimple> ChangePasswordAsync(ResponseSimple response, ChangePasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                {
                    response.Status.Message = "Belə bir user tapılmadı!";
                    return response;
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Şifrə yenilənmədi!";
                    return response;
                }

                response.Status.Message = "Şifrə yeniləndi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ChangePasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }


        ////Helper
        private async Task<string> GeneratePasswordResetTokenAsync(USER user)
        {
            var forgotePasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            return forgotePasswordToken;
        }
    }
}
