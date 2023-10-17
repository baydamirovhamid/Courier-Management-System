using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class StadiumFullied
{
    public int Id { get; set; }

    public int? StadiumId { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual STADIUM? Stadium { get; set; }
}
