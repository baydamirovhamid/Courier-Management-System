using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class STADIUM_FULLIED
{    
    [Column("id")]
    public int Id { get; set; }

    [Column("stadium_id")]
    public int? StadiumId { get; set; }

    [Column("start_time")]
    public int? StartTime { get; set; }

    [Column("end_time")]
    public int? EndTime { get; set; }

    [Column("created_at")]
    public DateOnly? CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateOnly? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    [Column("stadium")]
    public virtual Stadium? Stadium { get; set; }
}
