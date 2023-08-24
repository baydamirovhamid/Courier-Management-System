using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace billkill.manager.backend.Models
{
    public class AGREEMENT_DOC
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("AGREEMENT_ID")]
        public int AgreementId { get; set; }

        [Column("CONTENT")]
        public string? Content { get; set; }

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
