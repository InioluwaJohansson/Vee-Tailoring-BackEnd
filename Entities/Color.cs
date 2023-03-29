using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Color: AuditableEntity
{
    public string ColorName { get; set; }
    public string ColorCode { get; set; }
}
