using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
{
    public interface ICompanyEmployeeService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, CompanyEmployeeDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, CompanyEmployeeDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<CompanyEmployeeVM> GetByIdAsync(int id);
        Task<ResponseListTotal<CompanyEmployeeVM>> GetAll(ResponseListTotal<CompanyEmployeeVM> response, int page, int pageSize);
    }
}
