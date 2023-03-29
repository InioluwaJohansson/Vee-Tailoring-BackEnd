using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Material: AuditableEntity
{
    public string MaterialName { get; set; }
    public string MaterialUrl { get; set; }
    public decimal MaterialPrice { get; set; }
}
