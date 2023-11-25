namespace reserva.user.backend.DTO.RequestModels
{
    public class ReserveDto
    {
        public int? ClientId { get; set; }
        public int? StadiumId { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalAmount { get; set; }
    }
}
