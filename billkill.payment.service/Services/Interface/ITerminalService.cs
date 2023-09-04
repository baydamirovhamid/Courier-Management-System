using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.DTO.ResponseModels.Main;
using billkill.payment.service.Models;

namespace billkill.payment.service.Services.Interface
{
    public interface ITerminalService
    {
        Task<ResponseObject<TerminalBeforePaymentResponseDto>> GetDeptAsync(ResponseObject<TerminalBeforePaymentResponseDto> response, GetDeptDto model);

        Task<ResponseObject<TerminalAfterPaymentResponseDto>> PayAsync(ResponseObject<TerminalAfterPaymentResponseDto> response, PayDto model);

        Task<ResponseObject<TerminalAfterPaymentResponseDto>> CheckPaymentStatusAsync(ResponseObject<TerminalAfterPaymentResponseDto> response, TransactionDto model);
    }
}
