namespace V_Tailoring.Models.DTOs
{
    public class CreateMaterialDto
    {
        public string MaterialName { get; set; }
        public IFormFile MaterialUrl { get; set; }
        public decimal MaterialPrice { get; set; }
    }
    public class GetMaterialDto
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string MaterialUrl { get; set; }
        public decimal MaterialPrice { get; set; }
    }
    public class UpdateMaterialDto
    {
        public string MaterialName { get; set; }
        public IFormFile MaterialUrl { get; set; }
        public decimal MaterialPrice { get; set; }
    }
    public class MaterialResponseModel : BaseResponse
    {
        public GetMaterialDto Data { get; set; }
    }
    public class MaterialsResponseModel : BaseResponse
    {
        public ICollection<GetMaterialDto> Data { get; set; } = new HashSet<GetMaterialDto>();
    }
}
