using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class Reserve
{
     [Column("id"), Key]
        public int Id { get; set; }
    p

     [Column("client_id"), ]
        
    public int? ClientId { get; set; }

    [Column("stadium_id"), ]     
    public int? StadiumId { get; set; }

    [Column("date"), ]     
    public DateTime? Date { get; set; }

    [Column("total_amount"), ]     
    public int? TotalAmount { get; set; }

    [Column("created_at"), ]     
    public DateTime? CreatedAt { get; set; }

    [Column("created_by"), ]  
    public string? CreatedBy { get; set; }

    [Column("update_at"), ]  
    public DateTime? UpdatedAt { get; set; }

    [Column("update_by"), ]  
    public string? UpdatedBy { get; set; }

    [Column("is_deleted"), ]  
    public int? IsDeleted { get; set; }

    public virtual Stadium? Stadium { get; set; }
}
