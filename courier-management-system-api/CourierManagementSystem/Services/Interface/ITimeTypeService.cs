using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

namespace courier.management.system.Services.Interface
{
    public interface ITimeTypeService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, TimeTypeDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, TimeTypeDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<ResponseListTotal<TimeTypeVM>> GetAll(ResponseListTotal<TimeTypeVM> response, int page, int pageSize);
        Task<TimeTypeVM> GetByIdAsync(int id);
    }
}
