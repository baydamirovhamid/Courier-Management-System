using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

namespace courier.management.system.Services.Interface
{
    public interface IPaymentService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, PaymentDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, PaymentDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<PaymentVM> GetByIdAsync(int id);
        Task<ResponseListTotal<PaymentVM>> GetAll(ResponseListTotal<PaymentVM> response, int page, int pageSize);
    }
}
