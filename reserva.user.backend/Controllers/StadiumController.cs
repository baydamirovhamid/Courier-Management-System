using Microsoft.AspNetCore.Mvc;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Diagnostics;
using reserva.user.backend.Services.Interface;
using reserva.user.backend.DTO.ResponseModels.Inner;
using billkill.manager.backend.Services.Implementation;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public StadiumController(
            IStadiumService stadiumService,
            IValidationCommon validation,
            ILoggerManager logger
            ) {
            _stadiumService = stadiumService;
            _validation = validation;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateStadiumAsync(StadiumDto model)
        {
            //_logger.LogError("Hello world: Test Log");
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _stadiumService.CreateAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateStadiumAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateStadiumAsync(StadiumDto model, int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _stadiumService.UpdateAsync(response, model, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateStadiumAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteStadiumAsync(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _stadiumService.DeleteAsync(response, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteStadiumAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseObject<StadiumVM> response = new ResponseObject<StadiumVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response.Response = await _stadiumService.GetByIdAsync(id);
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
            ResponseListTotal<StadiumVM> response = new ResponseListTotal<StadiumVM>();
            response.Response = new ResponseTotal<StadiumVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _stadiumService.GetAll(response, page, pageSize);
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
