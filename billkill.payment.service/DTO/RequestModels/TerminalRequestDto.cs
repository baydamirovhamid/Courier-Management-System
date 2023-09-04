namespace billkill.payment.service.DTO.RequestModels
{
    public class TransactionDto
    {
        public string TransactionId { get; set; }
    }

    public class GetDeptDto: TransactionDto
    {
        public string SubscriberCode { get; set; }
    }

    public class PayDto : GetDeptDto
    {
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
    }
}
