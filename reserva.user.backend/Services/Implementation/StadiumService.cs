using AutoMapper;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Org.BouncyCastle.Utilities;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.ResponseModels.Main;
using reserva.user.backend.Extensions;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace reserva.user.backend.Services.Implementation
{
    public class StadiumService : IStadiumService
    {
        AppConfiguration config = new AppConfiguration();
        private readonly IRepository<STADIUM> _stadiums;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public StadiumService(
            IRepository<STADIUM> stadiums,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _stadiums = stadiums;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, StadiumDto model)
        {
            try
            {
                var stadium = _mapper.Map<STADIUM>(model);
                stadium.CreatedAt = DateTime.Now;
                _stadiums.Insert(stadium);
                await _stadiums.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, StadiumDto model, int id)
        {
            try
            {
                var stadium = _mapper.Map<STADIUM>(model);

                var stadiumDb = await _stadiums.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                stadium.Id = id;
                stadium.UpdatedAt = DateTime.Now;
                stadium.CreatedAt = stadiumDb.CreatedAt;

                _stadiums.Update(stadium);
                await _stadiums.SaveAsync();
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
                var stadium = await _stadiums.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _stadiums.Remove(stadium);
                await _stadiums.SaveAsync();
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

        public async Task<StadiumVM> GetByIdAsync(int id)
        {
            var db_model = await _stadiums.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<StadiumVM>(db_model);
        }

        public async Task<ResponseListTotal<StadiumVM>> GetAll(ResponseListTotal<StadiumVM> response, int page, int pageSize)
        {
            
            var db_data = await _stadiums.AllQuery.OrderByDescending(x=>x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<StadiumVM>>(db_data);
            return response;
        }

        public List<StadiumVMOrm> GetStadiumsOrm(int skip, int limit, ref decimal totalCount)
        {
            List<StadiumVMOrm> data = new List<StadiumVMOrm>();

            using (NpgsqlConnection connection = new NpgsqlConnection(config.ConnectionString))
            {
                connection.Open();
               
                string query =  _sqlService.GetStadiums(false);

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StadiumVMOrm ss = new StadiumVMOrm()
                            {
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                BranchName = reader.GetString(reader.GetOrdinal("branch_name")),
                                Code = reader.GetString(reader.GetOrdinal("code")),
                                Type = reader.GetString(reader.GetOrdinal("type")),
                                MinPrice = reader.GetInt32(reader.GetOrdinal("min_price"))
                            };
                            data.Add(ss);


                        }
                    }
                }
                query = _sqlService.GetStadiums(true);
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            totalCount = reader.GetInt32(reader.GetOrdinal("totalCount"));

                        }
                    }

                }
                return data;
            }
        }

    }
}
