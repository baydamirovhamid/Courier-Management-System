using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace billkill.payment.service.Models
{
    public class INVOICE
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("SUBSCRIBER_ID")]
        public int SubscriberId { get; set; }

        [Column("AGREEMENT_ID")]
        public int? AgreementId { get; set; }

        [Column("SPA_ID")]
        public int? SpaId { get; set; }

        [Column("ABONE_NUMBER")]
        public string? AboneNumber { get; set; }
            
        [Column("STATUS")]
        public bool STATUS { get; set; }

        [Column("COMMON_DEBT")]
        public double CommonDebt { get; set; }

        [Column("LAST_MONTH_DEBT")]
        public double LastMonthDebt { get; set; }

        [Column("THIS_MONTH_DEBT")]
        public double ThisMonthDebt { get; set; }

        [Column("CREATED_AT")]
        public DateTime? CreatedAt { get; set; }

        [Column("CREATED_BY")]
        public string? CreatedBy { get; set; }

        [Column("UPDATED_AT")]
        public DateTime? UpdatedAt { get; set; }

        [Column("UPDATED_BY")]
        public string? UpdatedBy { get; set; }

        public virtual SUBSCRIBER Subscriber { get; set; }
        public virtual SP_ABONE Spa { get; set; }
        public virtual AGREEMENT Aggreement { get; set; }

    }
}
