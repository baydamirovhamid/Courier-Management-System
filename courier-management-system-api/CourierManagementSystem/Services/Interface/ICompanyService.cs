using Microsoft.AspNetCore.JsonPatch;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface ICompanyService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, CompanyDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, CompanyDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<CompanyVM> GetByIdAsync(int id);
        Task<ResponseListTotal<CompanyVM>> GetAll(ResponseListTotal<CompanyVM> response, int page, int pageSize);
        Task<ResponseSimple> UpdateCompanyAsync(ResponseSimple response, CompanyDto model, int id);
        Task<ResponseSimple> PartiallyUpdateCompanyAsync(ResponseSimple response, int id, JsonPatchDocument<CompanyDto> model);
    }
}
