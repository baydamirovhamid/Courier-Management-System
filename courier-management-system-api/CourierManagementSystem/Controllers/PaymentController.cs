using Microsoft.AspNetCore.Mvc;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.HelperModels;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Interface;
using System.Diagnostics;

namespace courier.management.system.Controllers
{

    [Route("api/v1/[controller]")]
        [ApiController]
        public class PaymentController : ControllerBase
        {
            private readonly IPaymentService _paymentService;
            private readonly IValidationCommon _validation;
            private readonly ILoggerManager _logger;
            public PaymentController(
                IPaymentService paymentService,
                IValidationCommon validation,
                ILoggerManager logger
                )
            {
                _paymentService = paymentService;
                _validation = validation;
                _logger = logger;
            }

            [HttpPost]
            [Route("create")]
            public async Task<IActionResult> CreatePaymentAsync(PaymentDto model)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _paymentService.CreateAsync(response, model);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreatePaymentAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "A system error has occurred.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }

            [HttpPost]
            [Route("update")]
            public async Task<IActionResult> UpdatePaymentAsync(PaymentDto model, int id)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _paymentService.UpdateAsync(response, model, id);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdatePaymentAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "A system error has occurred.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }

            [HttpDelete]
            [Route("delete")]
            public async Task<IActionResult> DeletePaymentAsync(int id)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _paymentService.DeleteAsync(response, id);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeletePaymentAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "A system error has occurred.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }


        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseObject<PaymentVM> response = new ResponseObject<PaymentVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response.Response = await _paymentService.GetByIdAsync(id);
                if (response.Response == null)
                {
                    response.Status.Message = "Information not found!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetById)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A system error has occurred.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            ResponseListTotal<PaymentVM> response = new ResponseListTotal<PaymentVM>();
            response.Response = new ResponseTotal<PaymentVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _paymentService.GetAll(response, page, pageSize);
                if (response.Response.Data == null)
                {
                    response.Status.Message = "Information not found!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A system error has occurred.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
 }

