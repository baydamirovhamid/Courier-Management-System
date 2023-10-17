using reserva.user.backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace reserva.user.backend.Controllers
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

        //[HttpGet, Route("get-companies")]
        //public IActionResult GetCompanies()
        //{
        //    return Ok(new { Result = _lookupService.GetCompanies() });
        //}


    }
}
