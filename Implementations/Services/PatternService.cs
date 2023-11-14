using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Implementations.Services;

public class PatternService : IPatternService
{
    IPatternRepo _repository;
    public PatternService(IPatternRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreatePatternDto createPatternDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Patterns\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (createPatternDto.PatternUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(createPatternDto.PatternUrl.FileName);
            var filePath = Path.Combine(folderPath, createPatternDto.PatternUrl.FileName);
            var extension = Path.GetExtension(createPatternDto.PatternUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createPatternDto.PatternUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        var pattern = new Pattern()
        {
            PatternName = createPatternDto.PatternName,
            PatternUrl = imagePath,
            PatternPrice = createPatternDto.PatternPrice,
            ClothCategoryId = createPatternDto.ClothCategoryId,
            ClothGenderId = createPatternDto.ClothGenderId,
            IsDeleted = false
        };
        await _repository.Create(pattern);
        return new BaseResponse()
        {
            Message = "Pattern Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdatePatternDto updatePatternDto)
    {
        var updatedPattern = await _repository.GetById(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Patterns\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updatePatternDto.PatternUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updatePatternDto.PatternUrl.FileName);
            var filePath = Path.Combine(folderPath, updatePatternDto.PatternUrl.FileName);
            var extension = Path.GetExtension(updatePatternDto.PatternUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updatePatternDto.PatternUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (updatedPattern != null)
        {
            updatedPattern.PatternName = updatePatternDto.PatternName ?? updatedPattern.PatternName;
            updatedPattern.PatternUrl = imagePath ?? updatedPattern.PatternUrl;
            updatedPattern.PatternPrice = updatePatternDto.PatternPrice;
            updatedPattern.ClothCategoryId = updatePatternDto.ClothCategoryId;
            updatedPattern.ClothGenderId = updatePatternDto.ClothGenderId;
            await _repository.Update(updatedPattern);
            return new BaseResponse()
            {
                Message = "Pattern Updated Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Update Pattern Successfully",
                Status = false
            };
        }
    }
    public async Task<PatternResponseModel> GetById(int id)
    {
        var Pattern = await _repository.GetById(id);
        if (Pattern != null)
        {
            return new PatternResponseModel()
            {
                Data = GetDetails(Pattern),
                Message = "Pattern Retrieved Successfully",
                Status = true
            };
        }
        return new PatternResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Pattern Successfully",
            Status = false
        };
    }
    public async Task<PatternsResponseModel> GetByPatternName(string patternName)
    {
        var Patterns = await _repository.GetByName(patternName);
        if (Patterns != null)
        {
            List<GetPatternDto> PatternList = new List<GetPatternDto>();
            foreach (var Pattern in Patterns) PatternList.Add(GetDetails(Pattern));
            return new PatternsResponseModel()
            {
                Data = PatternList,
                Message = "Pattern Retrieved Successfully",
                Status = true
            };
        }
        return new PatternsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Pattern Successfully",
            Status = false
        };
    }
    public async Task<PatternsResponseModel> GetPatternByPrice(decimal price)
    {
        var Patterns = await _repository.GetPatternByPrice(price);
        if (Patterns != null)
        {
            List<GetPatternDto> PatternList = new List<GetPatternDto>();
            foreach (var Pattern in Patterns) PatternList.Add(GetDetails(Pattern));
            return new PatternsResponseModel()
            {
                Data = PatternList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new PatternsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public async Task<PatternsResponseModel> GetByClothCategory(int id)
    {
        var Patterns = await _repository.GetPatternByClothCategory(id);
        if (Patterns != null)
        {
            List<GetPatternDto> PatternList = new List<GetPatternDto>();
            foreach (var Pattern in Patterns) PatternList.Add(GetDetails(Pattern));
            return new PatternsResponseModel()
            {
                Data = PatternList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new PatternsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public async Task<PatternsResponseModel> GetByClothCategoryClothGender(int categoryId, int genderId)
    {
        var Patterns = await _repository.GetPatternByClothCategoryGender(categoryId, genderId);
        if (Patterns != null)
        {
            List<GetPatternDto> PatternList = new List<GetPatternDto>();
            foreach (var Pattern in Patterns) PatternList.Add(GetDetails(Pattern));
            return new PatternsResponseModel()
            {
                Data = PatternList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new PatternsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public async Task<PatternsResponseModel> GetAllPattern()
    {
        var Patterns = await _repository.List();
        if (Patterns != null)
        {
            List<GetPatternDto> PatternList = new List<GetPatternDto>();
            foreach (var Pattern in Patterns)       PatternList.Add(GetDetails(Pattern));
            return new PatternsResponseModel()
            {
                Data = PatternList,
                Message = "Patterns List Retrieved Successfully",
                Status = true
            };
        }
        return new PatternsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Patterns List Successfully",
            Status = false
        };
    }
    public GetPatternDto GetDetails(Pattern pattern)
    {
        
        return new GetPatternDto
        {
            PatternName = pattern.PatternName,
            PatternUrl = pattern.PatternUrl,
            PatternPrice = pattern.PatternPrice,
            GetClothCategoryDto = new GetClothCategoryDto()
            {
                Id = pattern.ClothCategories.Id,
                ClothName = pattern.ClothCategories.ClothName,
            },
            GetClothGenderDto = new GetClothGenderDto()
            {
                Id = pattern.ClothGender.Id,
                Gender = pattern.ClothGender.Gender,
            }
        };
    }
    public async Task<DashBoardResponse> PatternsDashboard()
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
            Message = "No Available Patterns!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivatePattern(int id)
    {
        var updatedPattern = await _repository.GetById(id);
        if (updatedPattern != null)
        {
            updatedPattern.IsDeleted = true;
            await _repository.Update(updatedPattern);
            return new BaseResponse()
            {
                Message = "Pattern Deleted Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Pattern Successfully",
                Status = false
            };
        }
    }
}
