using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;

public class ClothGenderService : IClothGenderService
{
    IClothGenderRepo _repository;
    public ClothGenderService(IClothGenderRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateClothGenderDto createClothGenderDto)
    {
        var clothCategory = new ClothGender()
        {
            Gender = createClothGenderDto.Gender,
            IsDeleted = false
        };
        await _repository.Create(clothCategory);
        return new BaseResponse()
        {
            Message = "New Cloth Gender Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateClothGenderDto updateClothGenderDto)
    {
        var ClothCategory = await _repository.GetById(id);
        if (ClothCategory != null)
        {
            ClothCategory.Gender = updateClothGenderDto.Gender ?? ClothCategory.Gender;
            await _repository.Update(ClothCategory);
            return new BaseResponse()
            {
                Message = "Cloth Gender Updated Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Update Cloth Category",
                Status = false
            };
        }
    }
    public async Task<ClothGenderResponseModel> GetById(int id)
    {
        var Gender = await _repository.GetById(id);
        if (Gender != null)
        {
            return new ClothGenderResponseModel()
            {
                Data = GetDetails(Gender),
                Message = "Cloth Category Retrieved Successfully",
                Status = true
            };
        }
        return new ClothGenderResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Cloth Category",
            Status = false
        };
    }
    public async Task<ClothGendersResponseModel> GetAllClothGender()
    {
        var clothGenders = await _repository.List();
        if (clothGenders != null)
        {
            return new ClothGendersResponseModel()
            {
                Data = clothGenders.Select(clothGender => GetDetails(clothGender)).ToList(),
                Message = "Cloth Gender List Retrieved Successfully",
                Status = true
            };
        }
        return new ClothGendersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Cloth Gender List Successfully",
            Status = false
        };
    }
    public GetClothGenderDto GetDetails(ClothGender clothGender)
    {
        return new GetClothGenderDto
        {
            Id = clothGender.Id,
            Gender = clothGender.Gender,
        };
    }
    public async Task<DashBoardResponse> ClothGenderDashboard()
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
            Message = "No Available Gender!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateClothGender(int id)
    {
        var response = await _repository.GetById(id);
        if (response != null)
        {
            response.IsDeleted = true;
            await _repository.Update(response);
            return new BaseResponse()
            {
                Message = "Cloth Gender Deleted Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Cloth Gender",
                Status = false
            };
        }
    }
}
