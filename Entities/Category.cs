using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Category: AuditableEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
