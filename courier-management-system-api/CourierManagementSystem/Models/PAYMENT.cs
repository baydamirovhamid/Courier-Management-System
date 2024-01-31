using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courier.management.system.Models;

public partial class PAYMENT
{
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("amount")]
    public int? Amount { get; set; }

    [Column("payment_date")]     
    public int? PaymentDate { get; set; }

    [Column("customer_id")]     
    public DateTime? CustomerId { get; set; }

    [Column("package_id")]
    public DateTime? PackageId { get; set; }

    [Column("created_at")]     
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]  
    public string? CreatedBy { get; set; }

    [Column("updated_at")]  
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]  
    public string? UpdatedBy { get; set; }


}
