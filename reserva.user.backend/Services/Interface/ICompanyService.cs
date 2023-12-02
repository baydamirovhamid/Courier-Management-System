using Microsoft.AspNetCore.JsonPatch;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Services.Implementation;

namespace reserva.user.backend.Services.Interface
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
