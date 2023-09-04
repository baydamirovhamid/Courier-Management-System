using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.payment.service.Models
{
    public class USER_AGREEMENT
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("AGREEMENT_ID")]
        public int AgreementId { get; set; }

        [Column("SUBSCRIBER_ID")]
        public int SubscriberId { get; set; }

        [Column("STATUS")]
        public bool Status { get; set; }

        [Column("CREATED_AT")]
        public DateTime? CreatedAt { get; set; }

        [Column("CREATED_BY")]
        public string? CreatedBy { get; set; }

        [Column("UPDATED_AT")]
        public DateTime? UpdatedAt { get; set; }

        [Column("UPDATED_BY")]
        public string? UpdatedBy { get; set; }
    }
}
