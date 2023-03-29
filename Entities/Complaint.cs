using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Complaint : AuditableEntity
{
    public string Email { get; set; }
    public string Description { get; set; }
    public bool IsSolved { get; set; }
}
