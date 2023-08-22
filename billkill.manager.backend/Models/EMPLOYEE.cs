using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace billkill.manager.backend.Models
{
    public class EMPLOYEE
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }

        [Column("ROLE_ID")]
        public int RoleId { get; set; }

        [Column("COMPANY_ID")]
        public string CompanyId { get; set; }
    }
}
