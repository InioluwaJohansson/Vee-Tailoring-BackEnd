using V_Tailoring.Contracts;
using V_Tailoring.Entities;

namespace V_Tailoring.Entities
{
    public class Collection : AuditableEntity
    {
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public ClothGender ClothGender { get; set; }
        public int ClothGenderId { get; set; }
        public ClothCategory ClothCategory { get; set; }
        public int ClothCategoryId { get; set; }
        public Template Template { get; set; }
        public int Pieces { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set;}
    }
}
