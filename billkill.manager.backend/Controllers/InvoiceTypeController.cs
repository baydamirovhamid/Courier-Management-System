using billkill.manager.backend.DTO.HelperModels;
using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.DTO.ResponseModels.Main;
using billkill.manager.backend.Models;
using billkill.manager.backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace billkill.manager.backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InvoiceTypeController : ControllerBase
    {
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;

        public InvoiceTypeController(
            IInvoiceTypeService invoiceTypeService,
            IValidationCommon validation, 
            ILoggerManager logger)
        {
            _invoiceTypeService = invoiceTypeService;
            _validation = validation;
            _logger = logger;
        }


        //[HttpPost]
        //[Route("create-invoice-type")]
        //public async Task<IActionResult> CreateInvoiceType(InvoiceType invoiceType)
        //{
        //    ResponseSimple response = new ResponseSimple();
        //    response.Status = new StatusModel();
        //    response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        //    try
        //    {
        //        response = await _invoiceTypeService.CreateInvoiceTypeAsync(response, invoiceType);
        //        if (response.Status.ErrorCode != 0)
        //        {
        //            return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
        //        }
        //        else
        //        {
        //            return Ok(response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateInvoiceType)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //        response.Status.Message = "Sistemdə xəta baş verdi.";
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpGet]
        //[Route("get-invoice-type")]
        //public async Task<IActionResult> GetInvoiceType(int id)
        //{
        //    ResponseObject<InvoiceType> response = new ResponseObject<InvoiceType>();
        //    response.Status = new StatusModel();
        //    response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        //    try
        //    {
        //        response = await _invoiceTypeService.GetInvoiceTypeAsync(response, id);
        //        if (response.Status.ErrorCode != 0)
        //        {
        //            return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
        //        }
        //        else
        //        {
        //            return Ok(response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetInvoiceType)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //        response.Status.Message = "Sistemdə xəta baş verdi.";
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpGet]
        //[Route("get-invoice-types")]
        //public async Task<IActionResult> GetInvoiceTypes()
        //{
        //    ResponseListTotal<InvoiceType> response = new ResponseListTotal<InvoiceType>();
        //    response.Status = new StatusModel();
        //    response.Response = new ResponseTotal<InvoiceType>();
        //    response.Response.Data = new List<InvoiceType>();
        //    response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        //    try
        //    {
        //        response = await _invoiceTypeService.GetInvoiceTypesAsync(response);
        //        if (response.Status.ErrorCode != 0)
        //        {
        //            return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
        //        }
        //        else
        //        {
        //            return Ok(response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetInvoiceTypes)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //        response.Status.Message = "Sistemdə xəta baş verdi.";
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, response);
        //    }
        //}
    }
}
