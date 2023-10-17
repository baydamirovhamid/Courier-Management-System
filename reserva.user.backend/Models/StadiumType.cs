using System;
using System.Collections.Generic;

namespace reserva.user.backend.Models;

public partial class STADIUMTYPE
{
    
    public int Id { get; set; }
    [Column("id"), Key]
    
    public string? Name { get; set; }
    [Column("name")]
   
    public string? Key { get; set; }
     [Column("key")]

    public virtual ICollection<Stadium> Stadia { get; set; } = new List<Stadium>();
}
