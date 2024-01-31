using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface IPackageService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, PackageDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, PackageDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<PackageVM> GetByIdAsync(int id);
        Task<ResponseListTotal<PackageVM>> GetAll(ResponseListTotal<PackageVM> response, int page, int pageSize);
    }
}
