using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Models.DTOs;

public class CreateCommentDto
{
    public int PostId { get; set; }
    public int CustomerId { get; set; }
    public string Comment { get; set; }
    public DateTime CommentDate { get; set; } = DateTime.Today;
}
public class GetCommentDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerImageUrl { get; set; }
    public string Comment { get; set; }
    public int Likes { get; set; }
    public DateTime CommentDate { get; set; }
}
public class UpdateCommentsLikesDto
{
    public int? Likes { get; set; }
}
public class CommentResponseModel : BaseResponse
{
    public GetCommentDto Data { get; set; }
}
public class CommentsResponseModel : BaseResponse
{
    public ICollection<GetCommentDto> Data { get; set; } = new HashSet<GetCommentDto>();
}
