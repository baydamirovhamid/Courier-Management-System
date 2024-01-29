using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
{
    public class StadiumFulliedService : IStadiumFulliedService
    {
        private readonly IRepository<STADIUM_FULLIED> _stadiumfullieds;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public StadiumFulliedService(
            IRepository<STADIUM_FULLIED> stadiumfullieds,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _stadiumfullieds = stadiumfullieds;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumFulliedDto model)
        {
            try
            {
                var stadiumfullied = _mapper.Map<STADIUM_FULLIED>(model);
                stadiumfullied.CreatedAt = DateTime.Now;
                _stadiumfullieds.Insert(stadiumfullied);
                await _stadiumfullieds.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumFulliedDto model, int id)
        {
            try
            {
                var stadiumfullied = _mapper.Map<STADIUM_FULLIED>(model);

                var stadiumfulliedDb = await _stadiumfullieds.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                stadiumfullied.Id = id;
                stadiumfullied.UpdatedAt = DateTime.Now;
                stadiumfullied.CreatedAt = stadiumfulliedDb.CreatedAt;

                _stadiumfullieds.Update(stadiumfullied);
                await _stadiumfullieds.SaveAsync();
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
                var stadiumfullied = await _stadiumfullieds.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _stadiumfullieds.Remove(stadiumfullied);
                await _stadiumfullieds.SaveAsync();
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



        public async Task<StadiumFulliedVM> GetByIdAsync(int id)
        {
            var db_model = await _stadiumfullieds.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<StadiumFulliedVM>(db_model);
        }

        public async Task<ResponseListTotal<StadiumFulliedVM>> GetAll(ResponseListTotal<StadiumFulliedVM> response, int page, int pageSize)
        {

            var db_data = await _stadiumfullieds.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<StadiumFulliedVM>>(db_data);
            return response;
        }


        public async Task<ResponseSimple> UpdateStadiumFulliedAsync(ResponseSimple response, StadiumFulliedDto model, int id)
        {
            try
            {
                var stadiumfullied = _mapper.Map<STADIUM_FULLIED>(model);
                var existingStadiumFullied = await _stadiumfullieds.AllQuery
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                stadiumfullied.Id = id;
                _stadiumfullieds.Update(stadiumfullied);
                await _stadiumfullieds.SaveAsync();
                response.Status.ErrorCode = 0;
                response.Status.Message = "Uğurla yeniləndi!";
            }

            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateStadiumFulliedAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }

            return response;
        }


        public async Task<ResponseSimple> PartiallyUpdateStadiumFulliedAsync(ResponseSimple response, int id, JsonPatchDocument<StadiumFulliedDto> model)
        {
            try
            {
                var existingStadiumFullied = await _stadiumfullieds.AllQuery
                .FirstOrDefaultAsync(x => x.Id == id);

                if (existingStadiumFullied == null)
                {
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    response.Status.Message = "Employee not found.";
                    return response;
                }

                var StadiumFulliedDto = _mapper.Map<StadiumFulliedDto>(existingStadiumFullied);

                model.ApplyTo(StadiumFulliedDto);

                _mapper.Map(StadiumFulliedDto, existingStadiumFullied);
                _stadiumfullieds.Update(existingStadiumFullied);
                await _stadiumfullieds.SaveAsync();
                response.Status.ErrorCode = 0;
                response.Status.Message = "Uğurla yeniləndi!";
            }

            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateStadiumFulliedAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

    }
}



        //public ResponseTotal<BUILDING> GetBuildings(int SpId, BuildingsFilterVM filterVM)
        //{
        //    int recordsToSkip = (filterVM.Page - 1) * filterVM.PageSize;

        //    var query = _buildings.AllQuery
        //        .Where(
        //                x =>
        //                x.IsDelete != true &&
        //                x.SpId == SpId &&
        //                (string.IsNullOrEmpty(filterVM.Name) ? true : x.Name.ToLower().Contains(filterVM.Name.ToLower())) &&
        //                (string.IsNullOrEmpty(filterVM.Address) ? true : x.Address.ToLower().Contains(filterVM.Address.ToLower()))
        //        )
        //        .OrderByDescending(x => x.UpdatedAt != null ? x.UpdatedAt : x.CreatedAt);

        //    var response = new ResponseTotal<BUILDING>();
        //    response.Total = query.Count();
        //    response.Data = query
        //        .Skip(recordsToSkip)
        //        .Take(filterVM.PageSize)
        //        .ToList();

        //    return response;
        //}

        //public ResponseTotal<BuildingExelVM> GetBuildingsExel(int SpId)
        //{
        //    var response = new ResponseTotal<BuildingExelVM>();
        //    response.Data = _buildings.AllQuery.Where(
        //        x =>
        //        x.IsDelete != true &&
        //        x.SpId == SpId)
        //        .OrderBy(x => x.Name)
        //        .Select(x=>new BuildingExelVM { Name=x.Name,Address=x.Address})
        //        .ToList();

        //    return response;
        //}

    

