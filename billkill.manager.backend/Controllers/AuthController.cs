using billkill.manager.backend.DTO.HelperModels;
using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.DTO.HelperModels.Jwt;
using billkill.manager.backend.DTO.RequestModels;
using billkill.manager.backend.DTO.ResponseModels.Main;
using billkill.manager.backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace billkill.manager.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;

        public AuthController(
            IAuthService authService,
            IValidationCommon validation,
            ILoggerManager logger)
        {
            _authService = authService;
            _validation = validation;
            _logger = logger;
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUserAsync(RegisterDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _authService.RegisterUserAsync(response, model);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(RegisterUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }


        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginUserAsync(LoginDto model)
        {
            ResponseObject<JwtResponse> response = new ResponseObject<JwtResponse>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _authService.LoginUserAsync(response, model);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(LoginUserAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _authService.ForgotPasswordAsync(response, email);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ForgotPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(string token, string email)
        {
            var model = new ResetPasswordDto { Token = token, Email = email };
            return Ok(model);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _authService.ResetPasswordAsync(response, model);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(ResetPasswordAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}
