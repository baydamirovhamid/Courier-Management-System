using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<PAYMENT> _paymentRepository;
        private readonly IRepository<PACKAGE> _packageRepository;

        private readonly IMapper _mapper;
        public LookupService(IRepository<PAYMENT> paymentRepository, IRepository<PACKAGE> packageRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<ResponseList<PaymentVM>> GetPaymentAsync(ResponseList<PaymentVM> response)
        {
            try
            {
                var result = await _paymentRepository.AllQuery.ToListAsync();

                response.Data = _mapper.Map<List<PaymentVM>>(result);

            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "A problem was occured!";
            }
            return response;
        }

        public async Task<ResponseList<PackageVM>> GetPackageAsync(ResponseList<PackageVM> response)
        {
            try
            {
                var result = await _packageRepository.AllQuery.ToListAsync();

                response.Data = _mapper.Map<List<PackageVM>>(result);

            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "A problem was occured!";
            }
            return response;
        }
    }
}

     