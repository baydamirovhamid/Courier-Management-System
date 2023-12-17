using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

public partial class StadiumVMOrm
{

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Type { get; set; }

    public string? BranchName { get; set; }
    public int? MinPrice { get; set; }

}
