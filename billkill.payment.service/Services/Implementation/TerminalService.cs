using billkill.payment.service.DTO.HelperModels.Const;
using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.DTO.ResponseModels.Main;
using billkill.payment.service.Infrastructure.Repository;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace billkill.payment.service.Services.Implementation
{
    public class TerminalService : ITerminalService
    {
        private readonly IRepository<INVOICE> _invoices;
        private readonly IRepository<PAYMENT_TYPE> _invoiceTypes;
        private readonly IRepository<PAYMENT> _payments;
        private readonly IRepository<AGREEMENT_SERVICE> _agreementServices;
        private readonly ILoggerManager _logger;

        public TerminalService(
            IRepository<INVOICE> invoices,
            IRepository<PAYMENT_TYPE> invoiceTypes,
            IRepository<PAYMENT> payments,
            IRepository<AGREEMENT_SERVICE> agreementServices,
            ILoggerManager logger)
        {        
            _invoiceTypes = invoiceTypes;
            _invoices = invoices;
            _payments = payments;
            _agreementServices = agreementServices;
            _logger = logger;
        }

        public async Task<ResponseObject<TerminalBeforePaymentResponseDto>> GetDeptAsync(ResponseObject<TerminalBeforePaymentResponseDto> response, GetDeptDto model)
        {
            try
            {
                var result = await _invoices.AllQuery
                .Include(x => x.Subscriber)
                .ThenInclude(x => x.User)
                .Include(x => x.Aggreement)
                .Include(x => x.Spa)
                .ThenInclude(x => x.Apartment)
                .FirstOrDefaultAsync(x => x.AboneNumber == model.SubscriberCode && !x.STATUS);

                if(result!=null)
                {
                    response.Response = new TerminalBeforePaymentResponseDto();
                    response.Response.Subscriber = result.Subscriber.User.UserName;
                    response.Response.SubscribtionName = result.Spa.Apartment.Address;
                    response.Response.Invoice = new InvoiceBaseDto();
                    response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                    response.Response.Invoice.Debt = result.CommonDebt;
                    response.Response.Invoice.Services = string.Join(",", _agreementServices.AllQuery.Include(x=>x.Service).Where(x=>x.AgreementId==result.AgreementId).ToList());

                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetDeptAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;

           

        }

        public async Task<ResponseObject<TerminalAfterPaymentResponseDto>> PayAsync(ResponseObject<TerminalAfterPaymentResponseDto> response, PayDto model)
        {
            try
            {
                var payment_old = _payments.AllQuery.FirstOrDefault(x => x.TransId == model.TransactionId);
                var result = await _invoices.AllQuery
                                   .Include(x => x.Subscriber)
                                   .ThenInclude(x => x.User)
                                   .Include(x => x.Aggreement)
                                   .Include(x => x.Spa)
                                   .ThenInclude(x => x.Apartment)
                                   .FirstOrDefaultAsync(x => x.AboneNumber == model.SubscriberCode && !x.STATUS);
                if (payment_old == null && result!=null)
                {
                    result.CommonDebt -= model.Amount;
                    result.UpdatedAt = DateTime.Now;

                    _invoices.Update(result);
                    await _invoices.SaveAsync();

                    PAYMENT payment = new PAYMENT();
                    payment.Amount = model.Amount;
                    payment.TransId = model.TransactionId;
                    payment.PaymentDate = model.PaymentDate;
                    payment.CreatedAt = DateTime.Now;
                    payment.UpdatedAt = DateTime.Now;

                    _payments.Insert(payment);
                    await _payments.SaveAsync();

                    if (result != null)
                    {
                        response.Response = new TerminalAfterPaymentResponseDto();
                        response.Response.Subscriber = result.Subscriber.User.UserName;
                        response.Response.SubscribtionName = result.Spa.Apartment.Address;
                        response.Response.Invoice = new InvoiceDto();
                        response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                        response.Response.Invoice.Debt = model.Amount;
                        response.Response.Invoice.PaymentDate = model.PaymentDate;
                        response.Response.Invoice.Services = string.Join(",", _agreementServices.AllQuery.Include(x => x.Service).Where(x => x.AgreementId == result.AgreementId).ToList());

                    }

                }



            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(PayAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;



        }

        public async Task<ResponseObject<TerminalAfterPaymentResponseDto>> CheckPaymentStatusAsync(ResponseObject<TerminalAfterPaymentResponseDto> response, TransactionDto model)
        {
            try
            {
                var payment = _payments.AllQuery.FirstOrDefault(x => x.TransId == model.TransactionId);
                if(payment != null) {
                   var result = await _invoices.AllQuery
                  .Include(x => x.Subscriber)
                  .ThenInclude(x => x.User)
                  .Include(x => x.Aggreement)
                  .Include(x => x.Spa)
                  .ThenInclude(x => x.Apartment)
                  .FirstOrDefaultAsync(x => x.Id == payment.InvoiceId);

                    if (result != null)
                    {
                        response.Response = new TerminalAfterPaymentResponseDto();
                        response.Response.Subscriber = result.Subscriber.User.UserName;
                        response.Response.SubscribtionName = result.Spa.Apartment.Address;
                        response.Response.Invoice = new InvoiceDto();
                        response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                        response.Response.Invoice.Debt = payment.Amount;
                        response.Response.Invoice.Services = string.Join(",", _agreementServices.AllQuery.Include(x => x.Service).Where(x => x.AgreementId == result.AgreementId).ToList());

                    }
                }
              

            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CheckPaymentStatusAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;



        }
    }
}
