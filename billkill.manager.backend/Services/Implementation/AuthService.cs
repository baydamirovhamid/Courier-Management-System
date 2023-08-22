using AutoMapper;
using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.DTO.HelperModels.Jwt;
using billkill.manager.backend.DTO.RequestModels;
using billkill.manager.backend.DTO.ResponseModels.Main;
using billkill.manager.backend.Extensions;
using billkill.manager.backend.Infrastructure.Repository;
using billkill.manager.backend.Models;
using billkill.manager.backend.Services.Interface;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace billkill.manager.backend.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<USER> _userManager;
        private readonly SignInManager<USER> _signInManager;
        private readonly ILoggerManager _logger;
        private readonly IRepository<EMPLOYEE> _employee;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEmailService _emailService;
        AppConfiguration config = new AppConfiguration();


        public AuthService(
            UserManager<USER> userManager,
            SignInManager<USER> signInManager,
            ILoggerManager logger,
            IRepository<EMPLOYEE> employee,
            IMapper mapper,
            IJwtHandler jwtHandler,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _employee = employee;
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

        public async Task<ResponseObject<JwtResponse>> LoginUserAsync(ResponseObject<JwtResponse> response, LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "İstifadəçi adı və ya şifrə yanlışdır!";
                    return response;
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
                response.Response = _jwtHandler.CreateToken(user);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginUserAsync)}: " + $"{e}");
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
                    await Task.Delay(2188);
                    response.Status.Message = "Şifrəni yeniləmək üçün emailinizə link göndərildi!";
                    return response;
                }

                var token = await GeneratePasswordResetTokenAsync(user);
                var link = config.MailUrl + $"auth/reset-password?token={token}&email={email}";
                _emailService.SendEmailForgetPassword(email, link);
                response.Status.Message = "Şifrəni yeniləmək üçün emailinizə link göndərildi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginUserAsync)}: " + $"{e}");
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
                    await Task.Delay(2188);
                    response.Status.Message = "Şifrə yeniləndi!";
                    return response;
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if(!result.Succeeded)
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

        //public async Task<ResponseSimple> RegisterEmployeeAsync(ResponseSimple response, UserDto model)
        //{
        //    try
        //    {
        //        var user = _mapper.Map<USER>(model);

        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (!result.Succeeded)
        //        {
        //            response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //            response.Status.Message = "Problem baş verdi!";
        //        }
        //        else
        //        {
        //            _employee.Insert(invoiceType);
        //            await _employee.SaveAsync();
        //            response.Status.Message = "Uğurla əlavə olundu!";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(RegisterAsync)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.DB;
        //        response.Status.Message = "Problem baş verdi!";
        //    }
        //    return response;
        //}

        //Helper
        private async Task<string> GeneratePasswordResetTokenAsync(USER user)
        {
            var forgotePasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            return forgotePasswordToken;
        }
    }
}
