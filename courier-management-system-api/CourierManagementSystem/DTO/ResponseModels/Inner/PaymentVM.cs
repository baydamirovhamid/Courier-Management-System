using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using courier.management.system.DTO.HelperModels.Const;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.DTO.ResponseModels.Main;

public partial class PaymentVM
{
    public int Id { get; set; }
    public int? Amount { get; set; }
    public int? PaymentDate { get; set; }
    public DateTime? CustomerId { get; set; }
    public DateTime? PackageId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
}