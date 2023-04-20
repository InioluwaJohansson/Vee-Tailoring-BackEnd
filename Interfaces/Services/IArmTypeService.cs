using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Interfaces.Services;

public interface IArmTypeService
{
    Task<BaseResponse> Create(CreateArmTypeDto createArmTypeDto);
    Task<BaseResponse> Update(int id, UpdateArmTypeDto updateArmTypeDto);
    Task<ArmTypeResponseModel> GetById(int id);
    Task<ArmTypesResponseModel> GetAllArmType();
    Task<DashBoardResponse> ArmTypeDashboard();
    Task<BaseResponse> DeActivateArmType(int id);
}
