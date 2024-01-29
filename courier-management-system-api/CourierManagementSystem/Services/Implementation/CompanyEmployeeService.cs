using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
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

        public async Task<CompanyEmployeeVM> GetByIdAsync(int id)
        {
            var db_model = await _employees.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CompanyEmployeeVM>(db_model);
        }

        public async Task<ResponseListTotal<CompanyEmployeeVM>> GetAll(ResponseListTotal<CompanyEmployeeVM> response, int page, int pageSize)
        {

            var db_data = await _employees.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<CompanyEmployeeVM>>(db_data);
            return response;
        }

        public async Task<ResponseSimple> UpdateEmployeeAsync(ResponseSimple response, CompanyEmployeeDto model, int id)
        {
            try
            {
                var employee = _mapper.Map<COMPANY_EMPLOYEE>(model);
                var existingEmployee = await _employees.AllQuery
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                employee.Id = id;
                _employees.Update(employee);
                await _employees.SaveAsync();
                response.Status.ErrorCode = 0;
                response.Status.Message = "Uğurla yeniləndi!";
            }

            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }

            return response;
        }


        public async Task<ResponseSimple> PartiallyUpdateEmployeeAsync(ResponseSimple response, int id, JsonPatchDocument<CompanyEmployeeDto> model)
        {
            try
            {
                var existingEmployee = await _employees.AllQuery
                .FirstOrDefaultAsync(x => x.Id == id);

                if (existingEmployee == null)
                {
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    response.Status.Message = "Employee not found.";
                    return response;
                }

                var employeeDto = _mapper.Map<CompanyEmployeeDto>(existingEmployee);

                model.ApplyTo(employeeDto);

                _mapper.Map(employeeDto, existingEmployee);
                _employees.Update(existingEmployee);
                await _employees.SaveAsync();
                response.Status.ErrorCode = 0;
                response.Status.Message = "Uğurla yeniləndi!";
            }

            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateEmployeeAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

    }
}
