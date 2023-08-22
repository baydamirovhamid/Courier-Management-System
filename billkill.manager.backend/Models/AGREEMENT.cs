using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.manager.backend.Models
{
    public class AGREEMENT
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("ADDRESS")]
        public string Address { get; set; }

        [Column("GRACE_PERIOD")]
        public int GracePeriod { get; set; }

        [Column("APARTMENT_ID")]
        public int ApartmentId { get; set; }

        [Column("NUM")]
        public string Num { get; set; }

        [Column("MTK_NUM")]
        public string MtkNum { get; set; }

        [Column("START_DATE")]
        public DateTime StartDate { get; set; }

        [Column("END_DATE")]
        public DateTime EndDate { get; set; }

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
