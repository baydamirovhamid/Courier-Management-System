using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reserva.user.backend.Models
{
    public class CLIENT
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("USER_ID")]
        public int UserId { get; set; }

        public virtual USER User { get; set; }
    }
}
