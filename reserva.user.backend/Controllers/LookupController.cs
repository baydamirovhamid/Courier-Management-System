﻿using Microsoft.AspNetCore.Mvc;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Diagnostics;
using reserva.user.backend.Services.Interface;
using reserva.user.backend.DTO.ResponseModels.Inner;


namespace reserva.user.backend.Controllers
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
