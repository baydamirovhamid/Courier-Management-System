using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class Stadium
{
     [Column("id"), Key]
    public int Id { get; set; }

     [Column("name"),]
    public string? Name { get; set; }

     [Column("code"),]
    public string? Code { get; set; }

     [Column("type_id"),]
    public int? TypeId { get; set; }

     [Column("branc_id"),]
    public int? BranchId { get; set; }

     [Column("has_recording"),]
    public int? HasRecording { get; set; }

     [Column("min_price"),]
    public int? MinPrice { get; set; }

     [Column("max_price"),]
    public int? MaxPrice { get; set; }

     [Column("created_at"),]
    public DateTime? CreatedAt { get; set; }

     [Column("created_by"),]
    public string? CreatedBy { get; set; }

     [Column("updated_at"),]
    public DateTime? UpdatedAt { get; set; }

     [Column("updated_by"),]
    public string? UpdatedBy { get; set; }

    public virtual CompanyBranch? Branch { get; set; }

   
}
