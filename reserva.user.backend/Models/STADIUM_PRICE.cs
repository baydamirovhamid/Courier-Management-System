using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva.user.backend.Models;

public partial class STADIUM_PRICE
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    [Column("time_type_id")]
    public int? TimeTypeId { get; set; }

    [Column("stadium_id")]
    public int? StadiumId { get; set; }

   // [Column("created_at")]
   // public DateTime? CreatedAt { get; set; }

    public virtual STADIUM? Stadium { get; set; }

    public virtual TIME_TYPE? TimeType { get; set; }
}
