using AutoMapper;
using Microsoft.EntityFrameworkCore;
using courier.management.system.DTO.HelperModels;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
{
    public class StadiumPrice : IStadiumPrice
    {
        private readonly IRepository<STADIUM_PRICE> _stadiumPrice;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public StadiumPrice(
            IRepository<STADIUM_PRICE> stadiumPrice,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _stadiumPrice = stadiumPrice;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumPriceDto model)
        {
            try
            {
                var stadiumPrice = _mapper.Map<STADIUM_PRICE>(model);
               // stadiumPrice.CreatedAt = DateTime.Now;
                _stadiumPrice.Insert(stadiumPrice);
                await _stadiumPrice.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumPriceDto model, int id)
        {
            try
            {
                var stadiumPrice = _mapper.Map<STADIUM_PRICE>(model);

                var stadiumPriceDb = await _stadiumPrice.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                stadiumPrice.Id = id;
           //     stadiumPrice.CreatedAt = stadiumPriceDb.CreatedAt;

                _stadiumPrice.Update(stadiumPrice);
                await _stadiumPrice.SaveAsync();
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
                var stadium = await _stadiumPrice.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _stadiumPrice.Remove(stadium);
                await _stadiumPrice.SaveAsync();
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
        public async Task<StadiumPriceVM> GetByIdAsync(int id)
        {
            var db_model = await _stadiumPrice.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<StadiumPriceVM>(db_model);
        }
        public async Task<ResponseListTotal<StadiumPriceVM>> GetAll(ResponseListTotal<StadiumPriceVM> response, int page, int pageSize)
        {

            var db_data = await _stadiumPrice.AllQuery.ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<StadiumPriceVM>>(db_data);
            return response;
        }
    }
}
