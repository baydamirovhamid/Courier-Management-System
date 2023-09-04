namespace billkill.payment.service.DTO.RequestModels
{
    public class InvoiceBaseDto
    {
        public double Debt { get; set; }
        public string Services { get; set; }
        public string SpAgreementNo { get; set; }
    }

    public class InvoiceDto : InvoiceBaseDto
    {
        public DateTime PaymentDate { get; set; }
    }

    public class TerminalBeforePaymentResponseDto
    {
        public InvoiceBaseDto Invoice { get; set; }
        public string Subscriber { get; set; }
        public string SubscribtionName { get; set; }
    }

    public class TerminalAfterPaymentResponseDto
    {
        public InvoiceDto Invoice { get; set; }
        public string Subscriber { get; set; }
        public string SubscribtionName { get; set; }
    }

}
