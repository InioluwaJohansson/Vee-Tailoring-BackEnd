using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interface.Services;

public interface IStyleService
{
    Task<BaseResponse> Create(CreateStyleDto createStyleDto);
    Task<BaseResponse> Update(int id, UpdateStyleDto updateStyleDto);
    Task<StyleResponseModel> GetById(int id);
    Task<StylesResponseModel> GetByStyleName(string styleName);
    Task<StylesResponseModel> GetStylesByClothCategory(int clothCategory);
    Task<StylesResponseModel> GetStylesByClothCategoryClothGender(int clothCategory, int clothGender);
    Task<StylesResponseModel> GetStylesByPrice(decimal price);
    Task<StylesResponseModel> GetAllStyles();
    Task<DashBoardResponse> StylesDashboard();
    Task<BaseResponse> DeActivateStyle(int id);
}
