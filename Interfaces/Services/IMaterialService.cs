using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface IMaterialService
{
    Task<BaseResponse> Create(CreateMaterialDto createMaterialDto);
    Task<BaseResponse> Update(int id, UpdateMaterialDto updateMaterialDto);
    Task<MaterialResponseModel> GetById(int id);
    Task<MaterialsResponseModel> GetByMaterialName(string MaterialName);
    Task<MaterialsResponseModel> GetByMaterialPrice(decimal price);
    Task<MaterialsResponseModel> GetAllMaterial();
    Task<DashBoardResponse> MaterialsDashboard();
    Task<BaseResponse> DeActivateMaterial(int id);
}
