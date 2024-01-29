using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

public partial class StadiumFulliedVM
{
    public int Id { get; set; }

    public int? StadiumId { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }
   
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
