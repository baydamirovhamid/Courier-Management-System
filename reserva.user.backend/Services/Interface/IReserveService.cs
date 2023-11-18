using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
{
    public interface IReserveService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, ReserveDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, ReserveDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
    }
}
