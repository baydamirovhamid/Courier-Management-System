using AutoMapper;
using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.HelperModels.Const;
using billkill.payment.service.DTO.HelperModels.Jwt;
using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.DTO.ResponseModels.Main;
using billkill.payment.service.Extensions;
using billkill.payment.service.Infrastructure.Repository;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace billkill.payment.service.Services.Implementation
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

  
        public ResponseObject<JwtResponse> GenerateToken(ResponseObject<JwtResponse> response, UserClaims
            model)
        {
            try
            {
                
                response.Response =  _jwtHandler.CreateToken(model);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GenerateToken)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

       
    }
}
