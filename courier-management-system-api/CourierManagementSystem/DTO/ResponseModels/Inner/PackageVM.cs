using System.ComponentModel.DataAnnotations.Schema;

namespace courier.management.system.DTO.ResponseModels.Inner
{
    public class PackageVM
    {
        public int Id { get; set; }
        public int? TrackingNumber { get; set; }
        public int? Weight { get; set; }
        public bool Status { get; set; }
        public int? CustomerId { get; set; }
        public int? CourierId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
