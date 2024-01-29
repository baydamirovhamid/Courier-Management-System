using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

public partial class StadiumVMOrm
{

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Type { get; set; }

    public string? BranchName { get; set; }
    public int? MinPrice { get; set; }

}
