namespace courier.management.system.DTO.RequestModels
{
    public class PackageDto
    {
        public int? TrackingNumber { get; set; }
        public int? Weight { get; set; }
        public bool? Status { get; set; }
        public int? CustomerId { get; set; }
        public int? CourierId { get; set; }
    }
}
