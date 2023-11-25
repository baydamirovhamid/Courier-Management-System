using Microsoft.AspNetCore.Mvc;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Interface;
using System.Diagnostics;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Controllers
{
   
        [Route("api/v1/[controller]")]
        [ApiController]
        public class ReserveController : ControllerBase
        {
            private readonly IReserveService _reserveService;
            private readonly IValidationCommon _validation;
            private readonly ILoggerManager _logger;
            public ReserveController(
                IReserveService reserveService,
                IValidationCommon validation,
                ILoggerManager logger
                )
            {
                _reserveService = reserveService;
                _validation = validation;
                _logger = logger;
            }

            [HttpPost]
            [Route("create")]
            public async Task<IActionResult> CreateReserveAsync(ReserveDto model)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _reserveService.CreateAsync(response, model);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateReserveAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "Sistemdə xəta baş verdi.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }

            [HttpPost]
            [Route("update")]
            public async Task<IActionResult> UpdateReserveAsync(ReserveDto model, int id)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _reserveService.UpdateAsync(response, model, id);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateReserveAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "Sistemdə xəta baş verdi.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }

            [HttpDelete]
            [Route("delete")]
            public async Task<IActionResult> DeleteReserveAsync(int id)
            {
                ResponseSimple response = new ResponseSimple();
                response.Status = new StatusModel();
                response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
                try
                {

                    response = await _reserveService.DeleteAsync(response, id);
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
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteReserveAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "Sistemdə xəta baş verdi.";
                    return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
                }
            }


        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseObject<ReserveVM> response = new ResponseObject<ReserveVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response.Response = await _reserveService.GetByIdAsync(id);
                if (response.Response == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetById)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            ResponseListTotal<ReserveVM> response = new ResponseListTotal<ReserveVM>();
            response.Response = new ResponseTotal<ReserveVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _reserveService.GetAll(response, page, pageSize);
                if (response.Response.Data == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
 }

