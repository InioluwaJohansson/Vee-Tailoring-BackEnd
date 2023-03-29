namespace Vee_Tailoring.Models.DTOs;

public class CreateClothCategoryDto
{
    public string? ClothName { get; set; }
}
public class GetClothCategoryDto
{
    public int Id { get; set; }
    public string ClothName { get; set; }
}
public class UpdateClothCategoryDto
{
    public string? ClothName { get; set; }
}
public class ClothCategoryResponseModel : BaseResponse
{
    public GetClothCategoryDto Data { get; set; }
}
public class ClothCategorysResponseModel : BaseResponse
{
    public ICollection<GetClothCategoryDto> Data { get; set; } = new HashSet<GetClothCategoryDto>();
}
