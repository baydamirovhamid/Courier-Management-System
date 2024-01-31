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
    public class PaymentService: IPaymentService
    {
        private readonly IRepository<PAYMENT> _payment;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        
        private readonly IMapper _mapper;

        public PaymentService(
            IRepository<PAYMENT> payment,
            ILoggerManager logger,
            IConfiguration configuration,
           
            IMapper mapper)
        {
            _payment = payment;
            _logger = logger;
            _configuration = configuration;
            
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, PaymentDto model)
        {
            try
            {
                var payment = _mapper.Map<PAYMENT>(model);
                payment.CreatedAt = DateTime.Now;
                _payment.Insert(payment);
                await _payment.SaveAsync();
                response.Status.Message = "Successfully paid!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Invalid!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, PaymentDto model, int id)
        {
            try
            {
                var payment = _mapper.Map<PAYMENT>(model);

                var paymentDb = await _payment.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                payment.Id = id;
                payment.UpdatedAt = DateTime.Now;
                payment.CreatedAt = paymentDb.CreatedAt;

                _payment.Update(payment);
                await _payment.SaveAsync();
                response.Status.Message = "Successfully updated";
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
                var package = await _payment.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _payment.Remove(package);
                await _payment.SaveAsync();
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
        public async Task<PaymentVM> GetByIdAsync(int id)
        {
            var db_model = await _payment.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PaymentVM>(db_model);
        }

        public async Task<ResponseListTotal<PaymentVM>> GetAll(ResponseListTotal<PaymentVM> response, int page, int pageSize)
        {

            var db_data = await _payment.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<PaymentVM>>(db_data);
            return response;
        }
    }
}
