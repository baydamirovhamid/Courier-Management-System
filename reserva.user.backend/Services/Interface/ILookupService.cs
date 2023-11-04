using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
{
    public interface ILookupService
    {
        Task<ResponseObject<StaticVM>> GetStaticDataAsync(ResponseObject<StaticVM> response, string key);
        Task<ResponseList<CompanyBranch>> GetCompanyBranch(ResponseList<CompanyBranch> response);
    }
}
