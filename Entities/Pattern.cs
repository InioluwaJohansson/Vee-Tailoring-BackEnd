using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Pattern: AuditableEntity
    {
        public string PatternName { get; set; }
        public string PatternUrl { get; set; }
        public ClothCategory ClothCategories { get; set; }
        public int ClothCategoryId { get; set; }
        public ClothGender ClothGender { get; set; }
        public int ClothGenderId { get; set; }
        public decimal PatternPrice { get; set; }
    }
}
