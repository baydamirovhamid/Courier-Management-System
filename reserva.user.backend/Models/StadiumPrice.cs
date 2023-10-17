using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class StadiumPrice
{
    public int Id { get; set; }

    public int? Price { get; set; }

    public int? TimeTypeId { get; set; }

    public int? StadiumId { get; set; }

    public virtual Stadium? Stadium { get; set; }

    public virtual TIME_TYPE? TimeType { get; set; }
}
