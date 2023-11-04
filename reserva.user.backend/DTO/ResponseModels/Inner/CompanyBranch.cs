namespace reserva.user.backend.DTO.ResponseModels.Inner
{
    public class CompanyBranch
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
