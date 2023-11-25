using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

public partial class ReserveVM
{
    public int Id { get; set; }
    public int? ClientId { get; set; }
    public int? StadiumId { get; set; }
    public DateTime? Date { get; set; }
    public int? TotalAmount { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDeleted { get; set; }

}