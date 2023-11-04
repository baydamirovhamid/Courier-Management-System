using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using reserva.user.backend.DTO.HelperModels.Const;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.DTO.ResponseModels.Main;

public partial class StadiumTypeVM
{

    public string? Name { get; set; }

    public string? Key { get; set; }

}
