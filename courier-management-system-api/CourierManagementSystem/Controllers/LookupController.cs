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
        [Route("get-payment")]
        public async Task<IActionResult> GetPayment()
        {
            ResponseList<PaymentVM> response = new ResponseList<PaymentVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetPaymentAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A system error has occurred.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-package")]
        public async Task<IActionResult> GetPackageData()
        {
            ResponseList<PackageVM> response = new ResponseList<PackageVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetPackageAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "A system error has occurred.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}
