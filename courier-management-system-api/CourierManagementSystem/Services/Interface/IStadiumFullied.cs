using Microsoft.AspNetCore.JsonPatch;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
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
