using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Services.Interface
{
    public interface ILookupService
    {
        Task<ResponseObject<StaticVM>> GetStaticDataAsync(ResponseObject<StaticVM> response, string key);
        Task<ResponseList<TimeTypeVM>> GetTimeTypeAsync(ResponseList<TimeTypeVM> response);
        Task<ResponseList<StadiumTypeVM>> GetStadiumTypeAsync(ResponseList<StadiumTypeVM> response);

    }
}
