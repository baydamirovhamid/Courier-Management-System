using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface ILookupService
    {
        Task<ResponseObject<StaticVM>> GetStaticDataAsync(ResponseObject<StaticVM> response, string key);
        Task<ResponseList<TimeTypeVM>> GetTimeTypeAsync(ResponseList<TimeTypeVM> response);
        Task<ResponseList<StadiumTypeVM>> GetStadiumTypeAsync(ResponseList<StadiumTypeVM> response);
        Task<ResponseList<CompanyVM>> GetCompanyAsync(ResponseList<CompanyVM> response);
        Task<ResponseList<CompanyBranch>> GetCompanyBranch(ResponseList<CompanyBranch> response);
    }
}
