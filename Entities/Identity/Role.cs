using Vee_Tailoring.Contracts;

namespace Vee_Tailoring.Entities.Identity;

public class Role : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
