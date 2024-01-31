using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace courier.management.system.Models;

public partial class PACKAGE
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("trackingNumber")]
    public int? TrackingNumber { get; set; }

    [Column("weight")]
    public int? Weight { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Column("courier_id")]
    public int? CourierId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    [Column("is_deleted")]
    public bool? IsDeleted { get; set; }
}
