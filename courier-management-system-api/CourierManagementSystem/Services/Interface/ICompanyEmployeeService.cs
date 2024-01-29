using Microsoft.AspNetCore.JsonPatch;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

namespace courier.management.system.Services.Interface
{
    public interface ICompanyEmployeeService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, CompanyEmployeeDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, CompanyEmployeeDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<CompanyEmployeeVM> GetByIdAsync(int id);
        Task<ResponseListTotal<CompanyEmployeeVM>> GetAll(ResponseListTotal<CompanyEmployeeVM> response, int page, int pageSize);
        Task<ResponseSimple> UpdateEmployeeAsync(ResponseSimple response, CompanyEmployeeDto model, int id);
        Task<ResponseSimple> PartiallyUpdateEmployeeAsync(ResponseSimple response, int id, JsonPatchDocument<CompanyEmployeeDto> model);
    }
}
