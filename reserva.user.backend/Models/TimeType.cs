using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class TimeType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? WeekDay { get; set; }

    public string? Time { get; set; }

    public string? Interval { get; set; }

    public virtual ICollection<StadiumPrice> StadiumPrices { get; set; } = new List<StadiumPrice>();
}
