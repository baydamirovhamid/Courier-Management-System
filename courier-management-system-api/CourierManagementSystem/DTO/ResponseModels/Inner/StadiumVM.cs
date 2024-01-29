using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

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
