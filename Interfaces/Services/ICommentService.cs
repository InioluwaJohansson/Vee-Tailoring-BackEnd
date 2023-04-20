using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface ICommentService
{
    Task<BaseResponse> Create(CreateCommentDto createCommentDto);
    Task<BaseResponse> UpdateLikes(int id);
    Task<CommentResponseModel> GetById(int id);
    Task<BaseResponse> DeActivateComment(int id);
}
