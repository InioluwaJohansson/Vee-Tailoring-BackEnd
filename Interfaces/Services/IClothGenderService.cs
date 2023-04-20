using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface IClothGenderService
{
    Task<BaseResponse> Create(CreateClothGenderDto createClothGenderDto);
    Task<BaseResponse> Update(int id, UpdateClothGenderDto updateClothGenderDto);
    Task<ClothGenderResponseModel> GetById(int id);
    Task<ClothGendersResponseModel> GetAllClothGender();
    Task<DashBoardResponse> ClothGenderDashboard();
    Task<BaseResponse> DeActivateClothGender(int id);
}
