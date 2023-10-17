using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class COMPANY_BRANCH
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    public virtual COMPANY Company { get; set; }

}
