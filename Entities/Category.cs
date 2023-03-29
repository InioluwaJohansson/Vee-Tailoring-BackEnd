using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Category: AuditableEntity
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
