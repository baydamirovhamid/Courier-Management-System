using System.ComponentModel.DataAnnotations.Schema;

namespace courier.management.system.DTO.RequestModels
{
    public class CompanyEmployeeDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? BranchId { get; set; }
    }
}
