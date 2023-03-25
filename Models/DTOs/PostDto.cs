using V_Tailoring.Entities;
namespace V_Tailoring.Models.DTOs
{
    public class CreatePostDto
    {
        public int CategoryId { get; set; }
        public string PostTitle { get; set; }
        public IFormFile PostImage { get; set; }
        public string PostDescription { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Today;
        public int ReadTime { get; set; }
        public int StaffId { get; set; }
    }
    public class GetPostDto
    {
        public int Id { get; set; }
        public GetCategoryDto GetCategoryDto { get; set; }
        public string PostTitle { get; set; }
        public string PostImage { get; set; }
        public string PostDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadTime { get; set; }
        public int Likes { get; set; }
        public string StaffName { get; set; }
        public string StaffImage { get; set; }
        public List<GetCommentDto> GetCommentDtos { get; set; } = new List<GetCommentDto>();
    }
    public class UpdatePostDto
    {
        public int CategoryId { get; set; }
        public string PostTitle { get; set; }
        public IFormFile PostImage { get; set; }
        public string PostDescription { get; set; }
        public int ReadTime { get; set; }
    }
    public class UpdatePostsLikesDto
    {
        public int Likes { get; set; }
    }
    public class PostResponseModel : BaseResponse
    {
        public GetPostDto Data { get; set; }
    }
    public class PostsResponseModel : BaseResponse
    {
        public ICollection<GetPostDto> Data { get; set; } = new HashSet<GetPostDto>();
    }
}
