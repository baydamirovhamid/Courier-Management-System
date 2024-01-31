namespace courier.management.system.DTO.RequestModels
{
    public class PaymentDto
    {
        public int? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CustomerId { get; set; }
        public int? PackageId { get; set; }

    }
}
