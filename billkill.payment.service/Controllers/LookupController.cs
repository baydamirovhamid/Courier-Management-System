using billkill.payment.service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace billkill.payment.service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet, Route("get-companies")]
        public IActionResult GetCompanies()
        {
            return Ok(new { Result = _lookupService.GetCompanies() });
        }

        [HttpGet, Route("get-buildings")]
        public IActionResult GetBuildings(int companyId)
        {
            return Ok(new { Result = _lookupService.GetBuildings(companyId) });
        }

        [HttpGet, Route("get-employee-roles")]
        public IActionResult GetEmployeeRoles()
        {
            return Ok(new { Result = _lookupService.GetEmployeeRoles() });
        }

        [HttpGet, Route("get-invoice-types")]
        public IActionResult GetInvoiceTypes()
        {
            return Ok(new { Result = _lookupService.GetInvoiceTypes() });
        }

        [HttpGet, Route("get-services")]
        public IActionResult GetServices()
        {
            return Ok(new { Result = _lookupService.GetServices() });
        }
    }
}
