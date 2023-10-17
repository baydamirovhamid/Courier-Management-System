using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class CompanyBranch
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? CompanyId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual COMPANY? Company { get; set; }

    public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; } = new List<CompanyEmployee>();

    public virtual ICollection<Stadium> Stadia { get; set; } = new List<Stadium>();
}
