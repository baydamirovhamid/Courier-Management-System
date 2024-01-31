using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;
using courier.management.system.Services.Implementation;

namespace courier.management.system.Services.Interface
{
    public interface ILookupService
    {
        Task<ResponseList<PaymentVM>> GetPaymentAsync(ResponseList<PaymentVM> response);
        Task<ResponseList<PackageVM>> GetPackageAsync(ResponseList<PackageVM> response);
      
    }
}
