using billkill.manager.backend.DTO.HelperModels;
using billkill.manager.backend.DTO.RequestModels;
using billkill.manager.backend.DTO.ResponseModels.Main;
using billkill.manager.backend.Models;

namespace billkill.manager.backend.Services.Interface
{
    public interface IInvoiceTypeService
    {
        Task<ResponseSimple> CreateInvoiceTypeAsync(ResponseSimple response, InvoiceTypeDto model);
        Task<ResponseObject<INVOICE_TYPE>> GetInvoiceTypeAsync(ResponseObject<INVOICE_TYPE> response, int id);
        Task<ResponseListTotal<INVOICE_TYPE>> GetInvoiceTypesAsync(ResponseListTotal<INVOICE_TYPE> response);
    }
}
