using V_Tailoring.Entities;
using V_Tailoring.Interface.Services;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Implementations.Services
{
    public class ArmTypeService : IArmTypeService
    {
        IArmTypeRepo _repository;
        public ArmTypeService(IArmTypeRepo repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse> Create(CreateArmTypeDto createArmTypeDto)
        {
            var armType = new ArmType()
            {
                ArmLength = createArmTypeDto.ArmLength,
                IsDeleted = false
            };
            await _repository.Create(armType);
            return new BaseResponse()
            {
                Message = "ArmType Successfully Added",
                Status = true,
            };
        }
        public async Task<BaseResponse> Update(int id, UpdateArmTypeDto updateArmTypeDto)
        {
            var updatedArmType = await _repository.GetById(id);
            if (updatedArmType != null)
            {
                updatedArmType.ArmLength = updateArmTypeDto.ArmLength ?? updatedArmType.ArmLength;
                var response = await _repository.Update(updatedArmType);
                if (response != null)
                {
                    return new BaseResponse()
                    {
                        Message = "Arm Updated Successfully",
                        Status = true,
                    };
                }
                else
                {
                    return new BaseResponse()
                    {
                        Message = "Arm Not Successfully Updated",
                        Status = false,
                    };
                }
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Arm Not Successfully Updated",
                    Status = false,
                };
            }
        }
        public async Task<ArmTypeResponseModel> GetById(int id)
        {
            var clothCategory = await _repository.GetById(id);
            if (clothCategory != null)
            {
                return new ArmTypeResponseModel()
                {
                    Data = GetDetails(clothCategory),
                    Message = "Arm Length Found",
                    Status = true
                };
            }
            return new ArmTypeResponseModel()
            {
                Data = null,
                Message = "Arm Length Found",
                Status = true
            };
         }
        public async Task<ArmTypesResponseModel> GetAllArmType()
        {
            var armTypes = await _repository.List();
            if (armTypes != null)
            {
                return new ArmTypesResponseModel() {
                    Data = armTypes.Select(armType => GetDetails(armType)).ToList(),
                    Message = "ArmTypes Found",
                    Status = true
                };
            }
            return new ArmTypesResponseModel()
            {
                Data = null,
                Message = "No ArmTypes Has",
                Status = false
            };
        }
        public GetArmTypeDto GetDetails(ArmType armType)
        {
            return new GetArmTypeDto
            {
                Id = armType.Id,
                ArmLength = armType.ArmLength,
            };
        }
        public async Task<DashBoardResponse> ArmTypeDashboard()
        {
            int total = (await _repository.GetAll()).Count;
            int active = (await _repository.GetByExpression(x => x.IsDeleted == false)).Count;
            int inActive = (await _repository.GetByExpression(x => x.IsDeleted == true)).Count;
            if (total != 0)
            {
                return new DashBoardResponse
                {
                    Total = total,
                    Active = active,
                    InActive = inActive,
                    Status = true,
                };
            }
            return new DashBoardResponse
            {
                Message = "No Available ArmType!",
                Status = false,
            };
        }
        public async Task<BaseResponse> DeActivateArmType(int id)
        {
            var response = await _repository.GetById(id);
            if (response != null)
            {
                response.IsDeleted = true;
                await _repository.Update(response);
                return new BaseResponse()
                {
                    Message = "ArmType Deleted Successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "ArmType Not Deleted Successfully",
                    Status = false
                };
            }
        }
    }
}
