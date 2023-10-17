using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reserva.user.backend.Models;

public partial class TIME_TYPE
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("week_day")]
    public string? WeekDay { get; set; }
    [Column("time")]
    public string? Time { get; set; }
    [Column("interval")]
    public string? Interval { get; set; }

}
