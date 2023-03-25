using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Color: AuditableEntity
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
