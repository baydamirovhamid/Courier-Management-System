using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courier.management.system.Models;

public partial class COURIER
{
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("name")]
     public string? Name { get; set; }

    [Column("surname")]
    public string Surname { get; set; }

    [Column("contact")]
    public string Contact { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("created_at")]
     public DateTime? CreatedAt { get; set; }

     [Column("created_by")]
     public string? CreatedBy { get; set; }

     [Column("updated_at")]
     public DateTime? UpdatedAt { get; set; }

     [Column("updated_by")]
     public string? UpdatedBy { get; set; }


}
