using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

public partial class CourierVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}
