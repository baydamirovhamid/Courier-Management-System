using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class STATIC
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("KEY")]
    public string? Key { get; set; }
}
