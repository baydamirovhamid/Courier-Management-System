using AutoMapper;
using courier.management.system.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;
using courier.management.system.Models;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Extensions;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.DTO.RequestModels.Auth;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.HelperModels.Jwt;

namespace courier.management.system.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<USER> _userManager;
        private readonly SignInManager<USER> _signInManager;
        private readonly ILoggerManager _logger;
        private readonly IRepository<CUSTOMER> _customers;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        AppConfiguration config = new AppConfiguration();

        public AuthService(
            UserManager<USER> userManager,
            SignInManager<USER> signInManager,
            ILoggerManager logger,
            IRepository<CUSTOMER> customers,
            IMapper mapper,
            IJwtHandler jwtHandler
            
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _customers = customers;
            _mapper = mapper;       
            _jwtHandler = jwtHandler;
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
                    response.Status.Message = "Invalid!";
                }
                else
                    response.Status.Message = "Successfully added!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(RegisterUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Invalid!";
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
                        response.Status.Message = "Username or password is incorrect!";
                        return response;
                    }
                  
                }
              
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Username or password is incorrect!";
                    return response;
                }
                if (!(await _signInManager.CanSignInAsync(user)))
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Login failed!";
                    return response;
                }
                var claims = _mapper.Map<JwtCustomClaims>(user);
                response.Response = _jwtHandler.CreateToken(claims);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A problem occurred!";
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
                    response.Status.Message = "User don't found!";
                    return response;
                }

                var token = await GeneratePasswordResetTokenAsync(user);
                token = HttpUtility.UrlEncode(token);    
                var link = config.MailUrl + $"reset-password?token={token}&email={email}";
              //  _emailService.SendEmailForgetPassword(email, link);
                response.Status.Message = "A link to reset your password has been sent to your email!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A problem occurred!";
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
                    response.Status.Message = "User doesn't found!";
                    return response;
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (!result.Succeeded)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Password doesn't updated!";
                    return response;
                }

                response.Status.Message = "Password updated!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ResetPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A problem occurred!";
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
                    response.Status.Message = "User doesn't found!";
                    return response;
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Password doesn't updated!";
                    return response;
                }

                response.Status.Message = "Password updated!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ChangePasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A problem occurred!";
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
