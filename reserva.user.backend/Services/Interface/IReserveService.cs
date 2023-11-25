using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Models;

namespace reserva.user.backend.Services.Interface
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
