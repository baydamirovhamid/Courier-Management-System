using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

public partial class StadiumFulliedVM
{
    public int Id { get; set; }

    public int? StadiumId { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }
   
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
