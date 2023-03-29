using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interface.Services;

public interface IPatternService
{
    Task<BaseResponse> Create(CreatePatternDto createPatternDto);
    Task<BaseResponse> Update(int id, UpdatePatternDto updatePatternDto);
    Task<PatternResponseModel> GetById(int id);
    Task<PatternsResponseModel> GetByPatternName(string patternName);
    Task<PatternsResponseModel> GetByClothCategory(int clothCategory);
    Task<PatternsResponseModel> GetByClothCategoryClothGender(int clothCategory, int clothGender);
    Task<PatternsResponseModel> GetPatternByPrice(decimal price);
    Task<PatternsResponseModel> GetAllPattern();
    Task<DashBoardResponse> PatternsDashboard();
    Task<BaseResponse> DeActivatePattern(int id);
}
