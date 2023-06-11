using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Models.DTOs;

public class CreateCollectionDto
{
    public string CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string CollectionDescription { get; set; }
    public int ClothGenderId { get; set; }
    public int ClothCategoryId { get; set; }
    public IFormFile ImageUrl { get; set; }
}
public class GetCollectionDto
{
    public int Id { get; set; }
    public string CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string CollectionDescription { get; set; }
    public string ClothGender { get; set; }
    public string ClothCategory { get; set; }
    public ICollection<GetTemplateDto> TemplateDto { get; set; } = new HashSet<GetTemplateDto>();
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
public class UpdateCollectionDto
{
    public string CollectionName { get; set; }
    public string CollectionDescription { get; set; }
    public int ClothGenderId { get; set; }
    public int ClothCategoryId { get; set; }
    public IFormFile ImageUrl { get; set; }
}
public class CollectionResponseModel : BaseResponse
{
    public GetCollectionDto Data { get; set; }
}
public class CollectionsResponseModel : BaseResponse
{
    public ICollection<GetCollectionDto> Data { get; set; } = new HashSet<GetCollectionDto>();
}
