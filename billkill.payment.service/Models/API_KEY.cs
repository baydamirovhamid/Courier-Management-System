using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.payment.service.Models
{
    public class API_KEY
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string? Name { get; set; }

        [Column("API_KEY")]
        public string? ApiKey { get; set; }
    }
}
