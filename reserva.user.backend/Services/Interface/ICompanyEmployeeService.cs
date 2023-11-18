using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;

namespace reserva.user.backend.Services.Interface
{
    public interface ICompanyEmployeeService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, CompanyEmployeeDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, CompanyEmployeeDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
    }
}
