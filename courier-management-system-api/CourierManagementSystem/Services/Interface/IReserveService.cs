using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Models;

namespace courier.management.system.Services.Interface
{
    public interface IReserveService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, ReserveDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, ReserveDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<ReserveVM> GetByIdAsync(int id);
        Task<ResponseListTotal<ReserveVM>> GetAll(ResponseListTotal<ReserveVM> response, int page, int pageSize);
    }
}
