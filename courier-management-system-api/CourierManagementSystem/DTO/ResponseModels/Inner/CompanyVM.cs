using System.ComponentModel.DataAnnotations.Schema;

namespace courier.management.system.DTO.ResponseModels.Inner
{
    public class CompanyVM
    {

        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
