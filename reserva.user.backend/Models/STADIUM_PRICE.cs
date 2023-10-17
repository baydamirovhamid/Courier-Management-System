using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class StadiumPrice
{
    [Column("id")]
    public int Id { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    [Column("time_type_id")]
    public int? TimeTypeId { get; set; }

    [Column("stadium_id")]
    public int? StadiumId { get; set; }

    [Column("stadium")]
    public virtual Stadium? Stadium { get; set; }

    [Column("time_type")]
    public virtual TIME_TYPE? TimeType { get; set; }
}
