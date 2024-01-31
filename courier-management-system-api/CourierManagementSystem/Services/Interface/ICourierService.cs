using Microsoft.AspNetCore.JsonPatch;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface ICourierService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response,CourierDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, CourierDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<CourierVM> GetByIdAsync(int id);
        Task<ResponseListTotal<CourierVM>> GetAll(ResponseListTotal<CourierVM> response, int page, int pageSize);     
    }
}
