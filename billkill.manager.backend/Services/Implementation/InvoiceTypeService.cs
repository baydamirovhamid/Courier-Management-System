using billkill.manager.backend.DTO.HelperModels;
using billkill.manager.backend.DTO.HelperModels.Const;
using billkill.manager.backend.DTO.ResponseModels.Main;
using billkill.manager.backend.Infrastructure.Repository;
using billkill.manager.backend.Models;
using billkill.manager.backend.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data.Common;

namespace billkill.manager.backend.Services.Implementation
{
    public class InvoiceTypeService : IInvoiceTypeService
    {
        //private readonly IRepository<Models.InvoiceType> _invoiceTypes;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;

        public InvoiceTypeService(
            //IRepository<InvoiceType> invoiceType, 
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService)
        {
            //_invoiceTypes = invoiceType;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;

        }
        //public async Task<ResponseSimple> CreateInvoiceTypeAsync(ResponseSimple response, Models.InvoiceType invoiceType)
        //{
        //    try
        //    {
        //        _invoiceTypes.Insert(invoiceType);
        //        await _invoiceTypes.SaveAsync();
        //        response.Status.Message = "Uğurla əlavə olundu!";
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateInvoiceTypeAsync)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.DB;
        //        response.Status.Message = "Problem baş verdi!";
        //    }
        //    return response;
        //}

        //public async Task<ResponseObject<InvoiceType>> GetInvoiceTypeAsync(ResponseObject<InvoiceType> response, int id)
        //{
        //    try
        //    {
        //        var invoiceType = await _invoiceTypes.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
        //        if (invoiceType == null)
        //        {
        //            response.Status.Message = "Tapılmadı!";
        //            response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
        //            return response;
        //        }
        //        response.Response = invoiceType;
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetInvoiceTypeAsync)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.DB;
        //        response.Status.Message = "Problem baş verdi!";
        //    }
        //    return response;
        //}

        //public async Task<ResponseListTotal<InvoiceType>> GetInvoiceTypesAsync(ResponseListTotal<InvoiceType> response)
        //{
        //    try
        //    {
        //        using (NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            NpgsqlCommand cmd;
        //            using (cmd = con.CreateCommand())
        //            {
        //                await con.OpenAsync();

        //                cmd.CommandText = _sqlService.GetInvoiceTypes();

        //                DbDataReader rdr = await cmd.ExecuteReaderAsync();

        //                while (await rdr.ReadAsync())
        //                {
        //                    InvoiceType encum = new InvoiceType();
        //                    {
        //                        encum.Id = (int)rdr["Id"];
        //                        encum.Name = rdr["Name"].ToString();
        //                    }
        //                    response.Response.Data.Add(encum);
        //                }
        //            }
        //            await con.CloseAsync();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetInvoiceTypeAsync)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.DB;
        //        response.Status.Message = "Problem baş verdi!";
        //    }
        //    return response;
        //}
    }
}
