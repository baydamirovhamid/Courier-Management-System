using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class RESERVE
{
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("client_id")]
        
    public int? ClientId { get; set; }

    [Column("stadium_id")]     
    public int? StadiumId { get; set; }

    [Column("date")]     
    public DateTime? Date { get; set; }

    [Column("total_amount")]     
    public int? TotalAmount { get; set; }

    [Column("created_at")]     
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]  
    public string? CreatedBy { get; set; }

    [Column("update_at")]  
    public DateTime? UpdatedAt { get; set; }

    [Column("update_by")]  
    public string? UpdatedBy { get; set; }

    [Column("is_deleted")]  
    public bool? IsDeleted { get; set; }

    public virtual STADIUM? Stadium { get; set; }
}
