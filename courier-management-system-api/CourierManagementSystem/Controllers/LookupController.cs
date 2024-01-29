using Microsoft.AspNetCore.Mvc;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.HelperModels;
using courier.management.system.DTO.ResponseModels.Main;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Diagnostics;
using courier.management.system.Services.Interface;
using courier.management.system.DTO.ResponseModels.Inner;


namespace courier.management.system.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService) {
            _lookupService = lookupService;
        }

        [HttpGet]
        [Route("get-static-data")]
        public async Task<IActionResult> GetStaticData(string key)
        {
            ResponseObject<StaticVM> response = new ResponseObject<StaticVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetStaticDataAsync(response, key);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-stadium-type")]
        public async Task<IActionResult> GetStadiumTypeData()
        {
            ResponseList<StadiumTypeVM> response = new ResponseList<StadiumTypeVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetStadiumTypeAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
        [HttpGet]
        [Route("get-time-type")]
        public async Task<IActionResult> GetTimeTypeData()
        {
            ResponseList<TimeTypeVM> response = new ResponseList<TimeTypeVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetTimeTypeAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-company")]
        public async Task<IActionResult> GetCompany()
        {
            ResponseList<CompanyVM> response = new ResponseList<CompanyVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetCompanyAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-company-branch")]
        public async Task<IActionResult> GetCompanyBranch()
        {
            ResponseList<CompanyBranch> response = new ResponseList<CompanyBranch>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetCompanyBranch(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}
