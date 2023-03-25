namespace V_Tailoring.Models.DTOs
{
    public class CreateComplaintDto
    {
        public string Email { get; set; }
        public string Description { get; set; }
    }
    public class GetComplaintDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsSolved { get; set; }
    }
    public class ComplaintResponseModel : BaseResponse
    {
        public GetComplaintDto Data { get; set; }
    }
    public class ComplaintsResponseModel : BaseResponse
    {
        public ICollection<GetComplaintDto> Data { get; set; } = new HashSet<GetComplaintDto>();
    }
}
