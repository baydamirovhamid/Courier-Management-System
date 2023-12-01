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
using Microsoft.AspNetCore.JsonPatch;

namespace reserva.user.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyEmployeeController : ControllerBase
    {
        private readonly ICompanyEmployeeService _employeeService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public CompanyEmployeeController(
            ICompanyEmployeeService employeeService,
            IValidationCommon validation,
            ILoggerManager logger
            )
        {
            _employeeService = employeeService;
            _validation = validation;
            _logger = logger;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployeeAsync(CompanyEmployeeDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _employeeService.CreateAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateEmployeeAsync(CompanyEmployeeDto model, int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _employeeService.UpdateAsync(response, model, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _employeeService.DeleteAsync(response, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPut]
        [Route("update-employee")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] CompanyEmployeeDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _employeeService.UpdateEmployeeAsync(response, model, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "An error occurred in the system.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPatch]
        [Route("update-employee-patch")]
        public async Task<IActionResult> PartiallyUpdateProduct(int id, [FromBody] JsonPatchDocument<CompanyEmployeeDto> model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _employeeService.PartiallyUpdateEmployeeAsync(response, id, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "An error occurred in the system.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}

