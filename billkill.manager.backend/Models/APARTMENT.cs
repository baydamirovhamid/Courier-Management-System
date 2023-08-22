using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.manager.backend.Models
{
    public class APARTMENT
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("SUBSCRIBER_CODE")]
        public string SubscriberCode { get; set; }

        [Column("BUILDING_ID")]
        public string BuildingId { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column("UPDATED_AT")]
        public DateTime UpdatedAt { get; set; }

        [Column("UPDATED_BY")]
        public string UpdatedBy { get; set; }
    }
}
