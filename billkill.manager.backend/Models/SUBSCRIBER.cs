using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.manager.backend.Models
{
    public class SUBSCRIBER
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("USER_ID")]
        public string UserId { get; set; }

        [Column("SUBSCRIBER_CODE")]
        public string SubscriberCode { get; set; }
    }
}
