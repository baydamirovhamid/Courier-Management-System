using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class STADIUM
{
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("name")]
     public string? Name { get; set; }

     [Column("code")]
     public string? Code { get; set; }

     [Column("type_id")]
     public int? TypeId { get; set; }

     [Column("branch_id")]
     public int? BranchId { get; set; }

     [Column("has_recording")]
     public bool? HasRecording { get; set; }

     [Column("min_price")]
     public int? MinPrice { get; set; }

     [Column("max_price")]
     public int? MaxPrice { get; set; }

     [Column("created_at")]
     public DateTime? CreatedAt { get; set; }

     [Column("created_by")]
     public string? CreatedBy { get; set; }

     [Column("updated_at")]
     public DateTime? UpdatedAt { get; set; }

     [Column("updated_by")]
     public string? UpdatedBy { get; set; }

     public virtual COMPANY_BRANCH? Branch { get; set; }

   
}
