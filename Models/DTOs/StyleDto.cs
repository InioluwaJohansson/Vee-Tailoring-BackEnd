namespace Vee_Tailoring.Models.DTOs;

public class CreateStyleDto
{
    public string StyleId { get; set; }
    public string StyleName { get; set; }
    public IFormFile StyleUrl { get; set; }
    public int ClothCategoryId { get; set; }
    public int ClothGenderId { get; set; }
    public decimal StylePrice { get; set; }
}
public class GetStyleDto
{
    public int Id { get; set; }
    public string StyleId { get; set; }
    public string StyleName { get; set; }
    public string StyleUrl { get; set; }
    public GetClothCategoryDto GetClothCategoryDto { get; set; }
    public GetClothGenderDto GetClothGenderDto { get; set; }
    public decimal StylePrice { get; set; }
}
public class UpdateStyleDto
{
    public string StyleName { get; set; }
    public IFormFile StyleUrl { get; set; }
    public int ClothCategoryId { get; set; }
    public int ClothGenderId { get; set; }
    public decimal StylePrice { get; set; }
}
public class StyleResponseModel : BaseResponse
{
    public GetStyleDto Data { get; set; }
}
public class StylesResponseModel : BaseResponse
{
    public ICollection<GetStyleDto> Data { get; set; } = new HashSet<GetStyleDto>();
}
