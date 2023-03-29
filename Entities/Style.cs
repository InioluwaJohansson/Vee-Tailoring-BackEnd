using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Style: AuditableEntity
{
    public string StyleId { get; set; }
    public string StyleName { get; set; }
    public string StyleUrl { get; set; }
    public int ClothCategoryId { get; set; }
    public ClothCategory ClothCategories { get; set; }
    public int ClothGenderId { get; set; }
    public ClothGender ClothGender { get; set; }
    public decimal StylePrice { get; set; }
    public bool? IsApproved { get; set; }
}
