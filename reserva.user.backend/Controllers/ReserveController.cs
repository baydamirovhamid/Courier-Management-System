using Microsoft.AspNetCore.Mvc;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Interface;
using System.Diagnostics;

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
        }
 }

