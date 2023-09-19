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
                var payment = GetPayment(model.TransactionId);
                if (payment == null)
                {
                    var result = await _invoices.AllQuery
                    .Include(x => x.Aggreement)
                    .Include(x => x.Spa)
                    .ThenInclude(x => x.Apartment)
                    .FirstOrDefaultAsync(x => x.AboneNumber == model.SubscriberCode && x.Status);

                    if (result != null)
                    {
                        response.Response = new TerminalBeforePaymentResponseDto();
                        response.Response.Subscriber = result.Spa.Apartment.Name;
                        response.Response.SubscribtionName = result.Spa.Apartment.Address;
                        response.Response.Invoice = new InvoiceBaseDto();
                        response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                        response.Response.Invoice.Debt = result.CommonDebt;
                        var services = _agreementServices.AllQuery.Include(x => x.Service).Where(x => x.AgreementId == result.AgreementId).Select(x => x.Service.Name).ToList();
                        response.Response.Invoice.Services = string.Join(",", services);

                    }
                    else
                    {
                        response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                        response.Status.Message = "Müraciət üzrə nəticə tapılmadı!";
                    }
                }
                else
                {
                    response.Status.ErrorCode = ErrorCodes.ALREADY_PAID;
                    response.Status.Message = "Qaimə artıq ödənilib!";
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
            using (var transaction = _payments.BeginTransaction())
            {
                try
                {
                    var payment_old = GetPayment(model.TransactionId);
                    var invoice = await _invoices.AllQuery
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.AboneNumber == model.SubscriberCode && x.Status);
                    if (payment_old == null && invoice != null)
                    {
                        invoice.CommonDebt -= model.Amount;
                        invoice.UpdatedAt = new DateTime();

                        _invoices.Update(invoice);
                        await _invoices.SaveAsync();

                        PAYMENT payment = new PAYMENT();
                        payment.Amount = model.Amount;
                        payment.TransId = model.TransactionId;
                        payment.PaymentDate = model.PaymentDate;
                        payment.InvoiceId = invoice.Id;
                        payment.TypeId = _invoiceTypes.AllQuery.FirstOrDefault(x => x.Key == "TERMINAL")?.Id;
                        payment.CreatedAt = new DateTime();
                        payment.UpdatedAt = new DateTime();

                        _payments.Insert(payment);
                        await _payments.SaveAsync();
                        var result = await _invoices.AllQuery
                                      .Include(x => x.Aggreement)
                                      .Include(x => x.Spa)
                                      .ThenInclude(x => x.Apartment)
                                      .FirstOrDefaultAsync(x => x.AboneNumber == model.SubscriberCode && x.Status);
                        if (result != null)
                        {
                            response.Response = new TerminalAfterPaymentResponseDto();
                            response.Response.Subscriber = result.Spa.Apartment.Name;
                            response.Response.SubscribtionName = result.Spa.Apartment.Address;
                            response.Response.Invoice = new InvoiceDto();
                            response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                            response.Response.Invoice.Debt = result.CommonDebt;
                            response.Response.Invoice.PaymentDate = model.PaymentDate;
                            var services = _agreementServices.AllQuery.Include(x => x.Service).Where(x => x.AgreementId == result.AgreementId).Select(x => x.Service.Name).ToList();
                            response.Response.Invoice.Services = string.Join(",", services);

                        }
                        transaction.Commit();

                    }
                    else
                    {
                        response.Status.ErrorCode = ErrorCodes.ALREADY_PAID;
                        response.Status.Message = "Qaimə artıq ödənilib!";
                    }



                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogError("TraceId: " + response.TraceID + $", {nameof(PayAsync)}: " + $"{e}");
                    response.Status.ErrorCode = ErrorCodes.SYSTEM;
                    response.Status.Message = "Problem baş verdi!";
                }
                return response;
            }


        }

        public async Task<ResponseObject<TerminalAfterPaymentResponseDto>> CheckPaymentStatusAsync(ResponseObject<TerminalAfterPaymentResponseDto> response, TransactionDto model)
        {
            try
            {
                var payment = GetPayment(model.TransactionId);
                if (payment!=null) {
                   var result = await _invoices.AllQuery
                  .Include(x => x.Aggreement)
                  .Include(x => x.Spa)
                  .ThenInclude(x => x.Apartment)
                  .FirstOrDefaultAsync(x => x.Id == payment.InvoiceId);

                    if (result != null)
                    {
                        response.Response = new TerminalAfterPaymentResponseDto();
                        response.Response.Subscriber = result.Spa.Apartment.Name;
                        response.Response.SubscribtionName = result.Spa.Apartment.Address;
                        response.Response.Invoice = new InvoiceDto();
                        response.Response.Invoice.SpAgreementNo = result.Aggreement.MtkNum;
                        response.Response.Invoice.Debt = payment.Amount;
                        var services = _agreementServices.AllQuery.Include(x => x.Service).Where(x => x.AgreementId == result.AgreementId).Select(x => x.Service.Name).ToList();
                        response.Response.Invoice.Services = string.Join(",", services);

                    }
                    else
                    {
                        response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                        response.Status.Message = "Müraciət üzrə nəticə tapılmadı!";
                    }
                }
                else
                {
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    response.Status.Message = "Müraciət üzrə nəticə tapılmadı!";
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

        private PAYMENT GetPayment(string transId)
        {
            return _payments.AllQuery.FirstOrDefault(x => x.TransId == transId);
        }
    }
}
