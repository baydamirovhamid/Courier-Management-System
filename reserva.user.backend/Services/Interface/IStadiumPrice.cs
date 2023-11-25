using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
{
    public interface IStadiumPrice
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumPriceDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumPriceDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
    }
}
