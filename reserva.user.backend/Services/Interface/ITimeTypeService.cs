using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
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
