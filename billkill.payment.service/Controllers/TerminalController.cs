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
    [Route("v1")]
    [ApiController]
    public class TerminalController: ControllerBase
    {
        private readonly ITerminalService _terminalService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TerminalController(
            ITerminalService terminalService,
            IValidationCommon validation,
            ILoggerManager logger,
            IMapper mapper)
        {
            _terminalService = terminalService;
            _validation = validation;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("getDebt")]
        public async Task<IActionResult> GetDeptAsync(GetDeptDto model)
        {
            ResponseObject<TerminalBeforePaymentResponseDto> response = new ResponseObject<TerminalBeforePaymentResponseDto>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _terminalService.GetDeptAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetDeptAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> PayAsync(PayDto model)
        {
            ResponseObject<TerminalAfterPaymentResponseDto> response = new ResponseObject<TerminalAfterPaymentResponseDto>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _terminalService.PayAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(PayAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("checkPaymentStatus")]
        public async Task<IActionResult> CheckPaymentStatusAsync(TransactionDto model)
        {
            ResponseObject<TerminalAfterPaymentResponseDto> response = new ResponseObject<TerminalAfterPaymentResponseDto>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _terminalService.CheckPaymentStatusAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CheckPaymentStatusAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

    }
}
