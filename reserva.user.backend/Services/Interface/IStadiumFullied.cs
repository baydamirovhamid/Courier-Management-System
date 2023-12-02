using Microsoft.AspNetCore.JsonPatch;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Services.Interface
{
    public interface IStadiumFulliedService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumFulliedDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumFulliedDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<StadiumFulliedVM> GetByIdAsync(int id);
        Task<ResponseListTotal<StadiumFulliedVM>> GetAll(ResponseListTotal<StadiumFulliedVM> response, int page, int pageSize);
        Task<ResponseSimple> UpdateStadiumFulliedAsync(ResponseSimple response, StadiumFulliedDto model, int id);
        Task<ResponseSimple> PartiallyUpdateStadiumFulliedAsync(ResponseSimple response, int id, JsonPatchDocument<StadiumFulliedDto> model);
    }
}
