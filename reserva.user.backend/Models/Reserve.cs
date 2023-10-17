using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class Reserve
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? StadiumId { get; set; }

    public DateOnly? Date { get; set; }

    public int? TotalAmount { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual Stadium? Stadium { get; set; }
}
