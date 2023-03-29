namespace Vee_Tailoring.Models.DTOs;

public class CreateCategoryDto
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
public class GetCategoryDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
public class UpdateCategoryDto
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
public class CategoryResponseModel : BaseResponse
{
    public GetCategoryDto Data { get; set; }
}
public class CategorysResponseModel : BaseResponse
{
    public ICollection<GetCategoryDto> Data { get; set; } = new HashSet<GetCategoryDto>();
}
