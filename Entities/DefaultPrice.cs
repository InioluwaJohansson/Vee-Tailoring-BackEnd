using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class DefaultPrice: AuditableEntity
{
    public string PriceName { get; set; }
    public decimal Price { get; set; }
}
