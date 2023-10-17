using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reserva.user.backend.Models;

public partial class STADIUM_TYPE
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("key")]
    public string? Key { get; set; }
}
