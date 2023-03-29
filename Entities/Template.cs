using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Template : AuditableEntity
{
    public string? TemplateId { get; set; }
    public string TemplateName { get; set; }
    public ClothGender ClothGender { get; set; }
    public int ClothGenderId { get; set; }
    public ClothCategory ClothCategory { get; set; }
    public int ClothCategoryId { get; set; }
    public Style Style { get; set; }
    public int StyleId { get; set; }
    public Pattern Pattern { get; set; }
    public int PatternId { get; set; }
    public Color Color { get; set; }
    public int ColorId { get; set; }
    public Material Material { get; set; }
    public int MaterialId { get; set; }
    public ArmType ArmType { get; set; }
    public int ArmTypeId { get; set; }
    public Collection Collection { get; set; }
    public int CollectionId { get; set; }
}
