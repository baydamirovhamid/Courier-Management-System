namespace courier.management.system.DTO.ResponseModels.Inner
{
    public class CompanyEmployeeVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? BranchId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
