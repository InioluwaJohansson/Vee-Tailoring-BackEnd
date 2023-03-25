using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Interface.Services
{
    public interface IClothCategoryService
    {
        Task<BaseResponse> Create(CreateClothCategoryDto createClothCategoryDto);
        Task<BaseResponse> Update(int id, UpdateClothCategoryDto updateClothCategoryDto);
        Task<ClothCategoryResponseModel> GetById(int id);
        Task<ClothCategorysResponseModel> GetAllClothCategory();
        Task<DashBoardResponse> ClothCategoryDashboard();
        Task<BaseResponse> DeActivateClothCategory(int id);
    }
}

