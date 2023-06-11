using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Implementations.Services;

public class StyleService : IStyleService
{
    IStyleRepo _repository;
    public StyleService(IStyleRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateStyleDto createStyleDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Style\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (createStyleDto.StyleUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(createStyleDto.StyleUrl.FileName);
            var filePath = Path.Combine(folderPath, createStyleDto.StyleUrl.FileName);
            var extension = Path.GetExtension(createStyleDto.StyleUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createStyleDto.StyleUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        var style = new Style()
        {
            StyleId = $"STYLE{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
            StyleName = createStyleDto.StyleName,
            StyleUrl = imagePath,
            ClothCategoryId = createStyleDto.ClothCategoryId,
            ClothGenderId = createStyleDto.ClothGenderId,
            StylePrice = createStyleDto.StylePrice,
            IsDeleted = false,
        };
        await _repository.Create(style);
        return new BaseResponse()
        {
            Message = "Style Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateStyleDto updateStyleDto)
    {
        var updatedStyle = await _repository.GetById(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Style\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updateStyleDto.StyleUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updateStyleDto.StyleUrl.FileName);
            var filePath = Path.Combine(folderPath, updateStyleDto.StyleUrl.FileName);
            var extension = Path.GetExtension(updateStyleDto.StyleUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateStyleDto.StyleUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (updatedStyle != null)
        {
            updatedStyle.StyleName = updateStyleDto.StyleName ?? updatedStyle.StyleName;
            updatedStyle.StyleUrl = imagePath ?? updatedStyle.StyleUrl;
            updatedStyle.StylePrice = updateStyleDto.StylePrice;
            updatedStyle.ClothCategoryId = updateStyleDto.ClothCategoryId;
            updatedStyle.ClothGenderId = updateStyleDto.ClothGenderId;
            await _repository.Update(updatedStyle);
            return new BaseResponse()
            {
                Message = "Style Updated Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Update Style Successfully",
                Status = false
            };
        }
    }
    public async Task<StyleResponseModel> GetById(int id)
    {
        var Style = await _repository.GetById(id);
        if (Style != null)
        {
            return new StyleResponseModel()
            {
                Data = GetDetails(Style),
                Message = "Style Retrieved Successfully",
                Status = true
            };
        }
        return new StyleResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Style Successfully",
            Status = false
        };
    }
    public async Task<StylesResponseModel> GetByStyleName(string styleName)
    {
        var Styles = await _repository.GetByStyleName(styleName);
        if (Styles != null)
        {
            List<GetStyleDto> StyleList = new List<GetStyleDto>();
            foreach (var Style in Styles) StyleList.Add(GetDetails(Style));
            return new StylesResponseModel()
            {
                Data = StyleList,
                Message = "Style Retrieved Successfully",
                Status = true
            };
        }
        return new StylesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Style Successfully",
            Status = false
        };
    }
    public async Task<StylesResponseModel> GetStylesByPrice(decimal price)
    {
        var Styles = await _repository.GetByStylePrice(price);
        if (Styles != null)
        {
            List<GetStyleDto> StyleList = new List<GetStyleDto>();
            foreach (var Style in Styles) StyleList.Add(GetDetails(Style));
            return new StylesResponseModel()
            {
                Data = StyleList,
                Message = "Styles List Retrieved Successfully",
                Status = true
            };
        }
        return new StylesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Styles List Successfully",
            Status = false
        };
    }
    public async Task<StylesResponseModel> GetStylesByClothCategory(int id)
    {
        var Styles = await _repository.GetByClothCategory(id);
        if (Styles != null)
        {
            List<GetStyleDto> StyleList = new List<GetStyleDto>();
            foreach (var Style in Styles) StyleList.Add(GetDetails(Style));
            return new StylesResponseModel()
            {
                Data = StyleList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new StylesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public async Task<StylesResponseModel> GetStylesByClothCategoryClothGender(int categoryId, int genderId)
    {
        var Styles = await _repository.GetByClothCategoryGender(categoryId, genderId);
        if (Styles != null)
        {
            List<GetStyleDto> StyleList = new List<GetStyleDto>();
            foreach (var Style in Styles) StyleList.Add(GetDetails(Style));
            return new StylesResponseModel()
            {
                Data = StyleList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new StylesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public async Task<StylesResponseModel> GetAllStyles()
    {
        var Patterns = await _repository.List();
        if (Patterns != null)
        {
            List<GetStyleDto> PatternList = new List<GetStyleDto>();
            foreach (var Pattern in Patterns)       PatternList.Add(GetDetails(Pattern));
            return new StylesResponseModel()
            {
                Data = PatternList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new StylesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public GetStyleDto GetDetails(Style style)
    {

        return new GetStyleDto
        {
            Id = style.Id,
            StyleName = style.StyleName,
            StyleUrl = style.StyleUrl,
            StylePrice = style.StylePrice,
            GetClothCategoryDto = new GetClothCategoryDto()
            {
                Id = style.ClothCategories.Id,
                ClothName = style.ClothCategories.ClothName,
            },
            GetClothGenderDto = new GetClothGenderDto()
            {
                Id = style.ClothGender.Id,
                Gender = style.ClothGender.Gender,
            }
        };
    }
    public async Task<DashBoardResponse> StylesDashboard()
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
            Message = "No Available Styles!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateStyle(int id)
    {
        var updatedStyle = await _repository.GetById(id);
        if (updatedStyle != null)
        {
            updatedStyle.IsDeleted = true;
            await _repository.Update(updatedStyle);
            return new BaseResponse()
            {
                Message = "Style Deleted Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Style Successfully",
                Status = false
            };
        }
    }
}
