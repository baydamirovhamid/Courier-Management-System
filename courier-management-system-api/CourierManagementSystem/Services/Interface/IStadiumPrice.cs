using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

namespace courier.management.system.Services.Interface
{
    public interface IStadiumPrice
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumPriceDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumPriceDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<StadiumPriceVM> GetByIdAsync(int id);
        Task<ResponseListTotal<StadiumPriceVM>> GetAll(ResponseListTotal<StadiumPriceVM> response, int page, int pageSize);
    }
}
