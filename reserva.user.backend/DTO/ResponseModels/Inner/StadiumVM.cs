using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

public partial class StadiumVM
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? TypeId { get; set; }

    public int? BranchId { get; set; }

    public bool? HasRecording { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
