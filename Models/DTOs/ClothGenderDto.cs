namespace V_Tailoring.Models.DTOs
{
    public class CreateClothGenderDto
    {
        public string Gender { get; set; }
    }
    public class GetClothGenderDto
    {
        public int Id { get; set; }
        public string Gender { get; set; }
    }
    public class UpdateClothGenderDto
    {
        public string? Gender { get; set; }
    }
    public class ClothGenderResponseModel : BaseResponse
    {
        public GetClothGenderDto Data { get; set; }
    }
    public class ClothGendersResponseModel : BaseResponse
    {
        public ICollection<GetClothGenderDto> Data { get; set; } = new HashSet<GetClothGenderDto>();
    }
}
