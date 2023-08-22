using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.manager.backend.Models
{
    public class INVOICE
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("SUBSCRIBER_ID")]
        public int SubscriberId { get; set; }

        [Column("PRICE")]
        public Decimal Price { get; set; }

        [Column("TRANS_ID")]
        public string TransId { get; set; }

        [Column("TYPE_ID")]
        public int TypeId { get; set; }

        [Column("AGREEMENT_ID")]
        public int AgreementId { get; set; }

        [Column("SERVICE_ID")]
        public int ServiceId { get; set; }

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
