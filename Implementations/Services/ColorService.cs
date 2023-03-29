using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Implementations.Services;

public class ColorService : IColorService
{
    IColorRepo _repository;
    public ColorService(IColorRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateColorDto createColorDto)
    {
        var Color = new Color()
        {
            ColorName = createColorDto.ColorName,
            ColorCode = createColorDto.ColorCode,
            IsDeleted = false
        };
        await _repository.Create(Color);
        return new BaseResponse()
        {
            Message = "Color added successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateColorDto updateColorDto)
    {
        var updatedColor = await _repository.GetById(id);
        if (updatedColor != null)
        {
            updatedColor.ColorName = updateColorDto.ColorName ?? updatedColor.ColorName;
            updatedColor.ColorCode = updateColorDto.ColorCode ?? updatedColor.ColorCode;
            var response = await _repository.Update(updatedColor);
            if (response != null)
            {
                return new BaseResponse()
                {
                    Message = "Color has been updated successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Color update failed",
                    Status = false
                };
            }
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Color update failed",
                Status = false
            };
        }
    }
    public async Task<ColorResponseModel> GetById(int id)
    {
        var Color = await _repository.GetById(id);
        if (Color != null)
        {
            return new ColorResponseModel()
            {
                Data = GetDetails(Color),
                Message = "Color Retrieved Successfully",
                Status = true,
            };
                
        }
        return new ColorResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Color Successfully",
            Status = false,
        };
    }
    public async Task<ColorsResponseModel> GetByColorName(string colorName)
    {
        var Colors = await _repository.GetbyColorName(colorName);
        if (Colors != null)
        {
            return new ColorsResponseModel()
            {
                Data = Colors.Select(Color => GetDetails(Color)).ToList(),
                Message = "Color Retrieved Successfully",
                Status = true,
            };

        }
        return new ColorsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Color Successfully",
            Status = false,
        };
    }
    public async Task<ColorsResponseModel> GetByColorCode(string colorCode)
    {
        var Colors = await _repository.GetbyColorName(colorCode);
        if (Colors != null)
        {
            return new ColorsResponseModel()
            {
                Data = Colors.Select(Color => GetDetails(Color)).ToList(),
                Message = "Colors Retrieved Successfully",
                Status = true,
            };

        }
        return new ColorsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Color Successfully",
            Status = false,
        };
    }
    public async Task<ColorsResponseModel> GetAllColor()
    {
        var Colors = await _repository.List();
        if (Colors != null)
        {
            return new ColorsResponseModel()
            {
                Data =  Colors.Select(Color => GetDetails(Color)).ToList(),
                Message = "Colors List Retrieved Successfully",
                Status = true
            };
               
        }
        return new ColorsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Colors List Successfully",
            Status = false
        };
    }
    public GetColorDto GetDetails(Color clothColor)
    {
        return new GetColorDto
        {
            Id = clothColor.Id,
            ColorName = clothColor.ColorName,
            ColorCode = clothColor.ColorCode,
        };
    }
    public async Task<DashBoardResponse> ColorDashboard()
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
            Message = "No Available Colors!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateColor(int id)
    {
        var response = await _repository.GetById(id);
        if (response != null)
        {
            response.IsDeleted = true;
            await _repository.Update(response);
            return new BaseResponse()
            {
                Message = "Color Deleted successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Color Successfully",
                Status = false
            };
        }
    }
}