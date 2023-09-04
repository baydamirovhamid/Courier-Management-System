using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace billkill.payment.service.Models
{
    public class PAYMENT
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("INVOICE_ID")]
        public int? InvoiceId { get; set; }

        [Column("TYPE_ID")]
        public int? TypeId { get; set; }

        [Column("AMOUNT")]
        public double Amount { get; set; }

        [Column("PAYMENT_DATE")]
        public DateTime? PaymentDate { get; set; }

        [Column("TRANS_ID")]
        public string TransId { get; set; }

        [Column("CREATED_AT")]
        public DateTime? CreatedAt { get; set; }

        [Column("CREATED_BY")]
        public string? CreatedBy { get; set; }

        [Column("UPDATED_AT")]
        public DateTime? UpdatedAt { get; set; }

        [Column("UPDATED_BY")]
        public string? UpdatedBy { get; set; }

        public virtual INVOICE Invoice { get; set; }
        public virtual PAYMENT_TYPE Type { get; set; }

    }
}
