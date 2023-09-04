using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.payment.service.Models
{
    public class SP_ABONE
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("ABONE_NUMBER")]
        public string? AboneNumber { get; set; }

        [Column("SP_ID")]
        public int? SpId { get; set; }

        [Column("APARTMENT_ID")]
        public int? ApartmentId { get; set; }

        [Column("CREATED_AT")]
        public DateTime? CreatedAt { get; set; }

        [Column("CREATED_BY")]
        public string? CreatedBy { get; set; }

        [Column("UPDATED_AT")]
        public DateTime? UpdatedAt { get; set; }

        [Column("UPDATED_BY")]
        public string? UpdatedBy { get; set; }

        public virtual SERVICE_PROVIDER Sp { get; set; }

        public virtual APARTMENT Apartment { get; set; }
    }
}
