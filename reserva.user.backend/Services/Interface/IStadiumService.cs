using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Services.Interface
{
    public interface IStadiumService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
    }
}
