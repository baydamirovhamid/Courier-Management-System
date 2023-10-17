using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class Stadium
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? TypeId { get; set; }

    public int? BranchId { get; set; }

    public int? HasRecording { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual COMPANY_BRANCH? Branch { get; set; }

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();

    public virtual ICollection<StadiumFullied> StadiumFullieds { get; set; } = new List<StadiumFullied>();

    public virtual ICollection<StadiumPrice> StadiumPrices { get; set; } = new List<StadiumPrice>();

    public virtual StadiumType? Type { get; set; }
}
