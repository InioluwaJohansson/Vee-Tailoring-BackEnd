using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Interfaces.Services;

public interface IClothCategoryService
{
    Task<BaseResponse> Create(CreateClothCategoryDto createClothCategoryDto);
    Task<BaseResponse> Update(int id, UpdateClothCategoryDto updateClothCategoryDto);
    Task<ClothCategoryResponseModel> GetById(int id);
    Task<ClothCategorysResponseModel> GetAllClothCategory();
    Task<DashBoardResponse> ClothCategoryDashboard();
    Task<BaseResponse> DeActivateClothCategory(int id);
}

