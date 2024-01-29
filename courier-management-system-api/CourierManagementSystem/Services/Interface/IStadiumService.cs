using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface IStadiumService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<StadiumVM> GetByIdAsync(int id);
        Task<ResponseListTotal<StadiumVM>> GetAll(ResponseListTotal<StadiumVM> response, int page, int pageSize);
    }
}
