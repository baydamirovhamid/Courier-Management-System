using AutoMapper;
using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.HelperModels.Const;
using billkill.payment.service.DTO.HelperModels.Jwt;
using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.DTO.ResponseModels.Main;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace billkill.payment.service.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthController(
            IAuthService authService,
            IValidationCommon validation,
            ILoggerManager logger,
            IMapper mapper)
        {
            _authService = authService;
            _validation = validation;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("generateToken")]
        [AllowAnonymous]
        public IActionResult GenerateToken(TerminalLoginDto model)
        {
            ResponseObject<JwtResponse> response = new ResponseObject<JwtResponse>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                var claims = _mapper.Map<UserClaims>(model);
                response =  _authService.GenerateToken(response, claims);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GenerateToken)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

    }
}
