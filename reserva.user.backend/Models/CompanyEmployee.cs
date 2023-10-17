using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class CompanyEmployee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? BranchId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual CompanyBranch? Branch { get; set; }
}
