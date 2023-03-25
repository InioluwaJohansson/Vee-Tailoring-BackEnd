namespace V_Tailoring.Models.DTOs
{
    public class CreateColorDto
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
    public class GetColorDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
    public class UpdateColorDto
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
    public class ColorResponseModel : BaseResponse
    {
        public GetColorDto Data { get; set; }
    }
    public class ColorsResponseModel : BaseResponse
    {
        public ICollection<GetColorDto> Data { get; set; } = new HashSet<GetColorDto>();
    }
}
