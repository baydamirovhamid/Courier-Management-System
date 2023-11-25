using AutoMapper;
using Microsoft.EntityFrameworkCore;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Interface;

namespace reserva.user.backend.Services.Implementation
{
    public class CompanyEmployeeService : ICompanyEmployeeService
    {
        private readonly IRepository<COMPANY_EMPLOYEE> _employees;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public CompanyEmployeeService(
            IRepository<COMPANY_EMPLOYEE> employees,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _employees = employees;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, CompanyEmployeeDto model)
        {
            try
            {
                var employee = _mapper.Map<COMPANY_EMPLOYEE>(model);
                employee.CreatedAt = DateTime.Now;
                _employees.Insert(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla əlavə olundu!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, CompanyEmployeeDto model, int id)
        {
            try
            {
                var employee = _mapper.Map<COMPANY_EMPLOYEE>(model);

                var employeeDb = await _employees.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                employee.Id = id;
                employee.UpdatedAt = DateTime.Now;
                employee.CreatedAt = employeeDb.CreatedAt;

                _employees.Update(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla yeniləndi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id)
        {
            try
            {
                var employee = await _employees.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _employees.Remove(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla silindi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }
    }
}
