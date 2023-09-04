using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.payment.service.Models
{
    public class SUBSCRIBER
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("USER_ID")]
        public int UserId { get; set; }

        [Column("SUBSCRIBER_CODE")]
        public string? SubscriberCode { get; set; }

        public virtual USER User { get; set; }
    }
}
