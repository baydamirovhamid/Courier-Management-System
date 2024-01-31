using AutoMapper;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Org.BouncyCastle.Utilities;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Extensions;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace courier.management.system.Services.Implementation
{
    public class CourierService : ICourierService
    {
        AppConfiguration config = new AppConfiguration();
        private readonly IRepository<COURIER> _couriers;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
       
        private readonly IMapper _mapper;

        public CourierService(
            IRepository<COURIER> couriers,
            ILoggerManager logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            _couriers = couriers;
            _logger = logger;
            _configuration = configuration;         
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, CourierDto model)
        {
            try
            {
                var courier = _mapper.Map<COURIER>(model);
                courier.CreatedAt = DateTime.Now;
                _couriers.Insert(courier);
                await _couriers.SaveAsync();
                response.Status.Message = "Courier found";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, CourierDto model, int id)
        {
            try
            {
                var courier = _mapper.Map<COURIER>(model);

                var courierDb = await _couriers.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                courier.Id = id;
                courier.UpdatedAt = DateTime.Now;
                courier.CreatedAt = courierDb.CreatedAt;

                _couriers.Update(courier);
                await _couriers.SaveAsync();
                response.Status.Message = "New courier found";
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
                var courier = await _couriers.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _couriers.Remove(courier);
                await _couriers.SaveAsync();
                response.Status.Message = "The courier was cancelled";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }

        public async Task<CourierVM> GetByIdAsync(int id)
        {
            var db_model = await _couriers.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CourierVM>(db_model);
        }

        public async Task<ResponseListTotal<CourierVM>> GetAll(ResponseListTotal<CourierVM> response, int page, int pageSize)
        {
            
            var db_data = await _couriers.AllQuery.OrderByDescending(x=>x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<CourierVM>>(db_data);
            return response;
        }

    }
}
