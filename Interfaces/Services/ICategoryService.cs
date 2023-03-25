using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Interface.Services
{
    public interface ICategoryService
    {
        Task<BaseResponse> Create(CreateCategoryDto createCategoryDto);
        Task<BaseResponse> Update(int id, UpdateCategoryDto updateCategoryDto);
        Task<CategoryResponseModel> GetById(int id);
        Task<CategorysResponseModel> GetAllCategory();
        Task<DashBoardResponse> CategoryDashboard();
        Task<BaseResponse> DeActivateCategory(int id);
    }
}
