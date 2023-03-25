namespace V_Tailoring.Models.DTOs
{
    public class CreateTemplateDto
    {
        public string TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ClothGenderId { get; set; }
        public int ClothCategoryId { get; set; }
        public int StyleId { get; set; }
        public int PatternId { get; set; }
        public int ColorId { get; set; }
        public int MaterialId { get; set; }
        public int ArmTypeId { get; set; }
        public int CollectionId { get; set; }
    }
    public class GetTemplateDto
    {
        public int Id { get; set; }
        public string TemplateId { get; set; }
        public string TemplateName { get; set; }
        public GetStyleDto GetStyleDto { get; set; }
        public GetPatternDto GetPatternDto { get; set; }
        public GetColorDto GetColorDto { get; set; }
        public GetMaterialDto GetMaterialDto { get; set; }
        public GetArmTypeDto GetArmTypeDto { get; set; }
        public GetCollectionDto GetCollectionDto { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateTemplateDto
    {
        public string TemplateName { get; set; }
        public int ClothGenderId { get; set; }
        public int ClothCategoryId { get; set; }
        public int StyleId { get; set; }
        public int PatternId { get; set; }
        public int ColorId { get; set; }
        public int MaterialId { get; set; }
        public int ArmTypeId { get; set; }
        public int CollectionId { get; set; }
    }
    public class TemplateResponseModel : BaseResponse
    {
        public GetTemplateDto Data { get; set; }
    }
    public class TemplatesResponseModel : BaseResponse
    {
        public ICollection<GetTemplateDto> Data { get; set; } = new HashSet<GetTemplateDto>();
    }
}
