using V_Tailoring.Entities;
namespace V_Tailoring.Models.DTOs
{
    public class CreatePatternDto
    {
        public string PatternName { get; set; }
        public IFormFile PatternUrl { get; set; }
        public decimal PatternPrice { get; set; }
        public int ClothCategoryId { get; set; }
        public int ClothGenderId { get; set; }
    }
    public class GetPatternDto
    {
        public int Id { get; set; }
        public string PatternName { get; set; }
        public string PatternUrl { get; set; }
        public decimal PatternPrice { get; set; }
        public GetClothCategoryDto GetClothCategoryDto { get; set; }
        public GetClothGenderDto GetClothGenderDto { get; set; }
    }
    public class UpdatePatternDto
    {
        public string PatternName { get; set; }
        public IFormFile PatternUrl { get; set; }
        public decimal PatternPrice { get; set; }
        public int ClothCategoryId { get; set; }
        public int ClothGenderId { get; set; }
    }
    public class PatternResponseModel : BaseResponse
    {
        public GetPatternDto Data { get; set; }
    }
    public class PatternsResponseModel : BaseResponse
    {
        public ICollection<GetPatternDto> Data { get; set; } = new HashSet<GetPatternDto>();
    }
}
