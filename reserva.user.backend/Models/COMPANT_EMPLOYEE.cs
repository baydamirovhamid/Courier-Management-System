using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class COMPANT_EMPLOYEE
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("surname")]
    public string? Surname { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    public virtual COMPANY_BRANCH Branch { get; set; }
}
