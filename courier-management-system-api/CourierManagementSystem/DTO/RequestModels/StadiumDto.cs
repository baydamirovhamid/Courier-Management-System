namespace courier.management.system.DTO.RequestModels
{
    public class StadiumDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? TypeId { get; set; }
        public int? BranchId { get; set; }
        public bool? HasRecording { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

    }
}
