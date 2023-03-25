using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Material: AuditableEntity
    {
        public string MaterialName { get; set; }
        public string MaterialUrl { get; set; }
        public decimal MaterialPrice { get; set; }
    }
}
