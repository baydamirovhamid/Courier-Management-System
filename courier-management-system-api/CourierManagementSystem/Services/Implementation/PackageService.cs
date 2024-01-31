using AutoMapper;
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
    public class PackageService : IPackageService
    {
        private readonly IRepository<PACKAGE> _packages;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
       
        private readonly IMapper _mapper;

        public PackageService(
            IRepository<PACKAGE> packages,
            ILoggerManager logger,
            IConfiguration configuration,
            
            IMapper mapper)
        {
            _packages = packages;
            _logger = logger;
            _configuration = configuration;
           
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, PackageDto model)
        {
            try
            {
                var package = _mapper.Map<PACKAGE>(model);
                _packages.Insert(package);
                await _packages.SaveAsync();
                response.Status.Message = "Successfully added!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, PackageDto model, int id)
        {
            try
            {
                var package = _mapper.Map<PACKAGE>(model);

                var packageDb = await _packages.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                package.Id = id;
                _packages.Update(package);
                await _packages.SaveAsync();
                response.Status.Message = "Successfully added!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }

        public async Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id)
        {
            try
            {
                var package = await _packages.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _packages.Remove(package);
                await _packages.SaveAsync();
                response.Status.Message = "Successfully deleted!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }
        public async Task<PackageVM> GetByIdAsync(int id)
        {
            var db_model = await _packages.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PackageVM>(db_model);
        }
        public async Task<ResponseListTotal<PackageVM>> GetAll(ResponseListTotal<PackageVM> response, int page, int pageSize)
        {

            var db_data = await _packages.AllQuery.OrderByDescending(x => x).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<PackageVM>>(db_data);
            return response;
        }
    }
}
