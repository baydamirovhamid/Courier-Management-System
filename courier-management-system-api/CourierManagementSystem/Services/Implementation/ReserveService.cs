using AutoMapper;
using Microsoft.EntityFrameworkCore;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
{
    public class ReserveService: IReserveService
    {
        private readonly IRepository<RESERVE> _reserves;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public ReserveService(
            IRepository<RESERVE> reserves,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _reserves = reserves;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, ReserveDto model)
        {
            try
            {
                var reserve = _mapper.Map<RESERVE>(model);
                reserve.CreatedAt = DateTime.Now;
                _reserves.Insert(reserve);
                await _reserves.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, ReserveDto model, int id)
        {
            try
            {
                var reserve = _mapper.Map<RESERVE>(model);

                var reserveDb = await _reserves.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                reserve.Id = id;
                reserve.UpdatedAt = DateTime.Now;
                reserve.CreatedAt = reserveDb.CreatedAt;

                _reserves.Update(reserve);
                await _reserves.SaveAsync();
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
                var stadium = await _reserves.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _reserves.Remove(stadium);
                await _reserves.SaveAsync();
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
        public async Task<ReserveVM> GetByIdAsync(int id)
        {
            var db_model = await _reserves.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ReserveVM>(db_model);
        }

        public async Task<ResponseListTotal<ReserveVM>> GetAll(ResponseListTotal<ReserveVM> response, int page, int pageSize)
        {

            var db_data = await _reserves.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<ReserveVM>>(db_data);
            return response;
        }
    }
}
