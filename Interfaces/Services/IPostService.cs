using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Interface.Services
{
    public interface IPostService
    {
        Task<BaseResponse> Create(CreatePostDto createPostDto);
        Task<BaseResponse> Update(int id, UpdatePostDto updatePostDto);
        Task<BaseResponse> UpdateLikes(int id);
        Task<PostResponseModel> GetById(int id);
        Task<PostsResponseModel> GetByPostTitle(string postTitle);
        Task<PostsResponseModel> GetByCategoryId(int categoryId);
        Task<PostsResponseModel> GetAllPosts();
        Task<DashBoardResponse> PostsDashboard();
        Task<BaseResponse> DeActivatePost(int id);
    }
}
