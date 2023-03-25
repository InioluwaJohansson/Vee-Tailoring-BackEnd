using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Interface.Services
{
    public interface ICommentService
    {
        Task<BaseResponse> Create(CreateCommentDto createCommentDto);
        Task<BaseResponse> UpdateLikes(int id);
        Task<CommentResponseModel> GetById(int id);
        Task<BaseResponse> DeActivateComment(int id);
    }
}
