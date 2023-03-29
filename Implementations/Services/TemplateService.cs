using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Security.AccessControl;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class TemplateService : ITemplateService
{
    ITemplateRepo _repository;
    IStyleRepo _stylerepository;
    IPatternRepo _patternrepository;
    IMaterialRepo _materialrepository;
    IColorRepo _colorrepository;
    IArmTypeRepo _armTyperepository;
    IClothGenderRepo _clothGenderrepository;
    IClothCategoryRepo _clothCategoryrepository;
    public TemplateService(ITemplateRepo repository, IStyleRepo styleRepo, IPatternRepo patternRepo, IMaterialRepo materialRepo, IColorRepo colorRepo, IArmTypeRepo armTypeRepo, IClothCategoryRepo clothCategoryRepo, IClothGenderRepo clothGenderRepo)
    {
        _repository = repository;
        _stylerepository = styleRepo;
        _patternrepository = patternRepo;
        _materialrepository = materialRepo;
        _colorrepository = colorRepo;
        _armTyperepository = armTypeRepo;
        _clothCategoryrepository = clothCategoryRepo;
        _clothGenderrepository = clothGenderRepo;
    }
    public async Task<BaseResponse> Create(CreateTemplateDto createTemplateDto)
    {
        var template = new Template()
        {
            TemplateId = $"TEMPLATE{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
            TemplateName = createTemplateDto.TemplateName,
            StyleId = createTemplateDto.StyleId,
            PatternId = createTemplateDto.PatternId,
            MaterialId = createTemplateDto.MaterialId,
            ColorId = createTemplateDto.ColorId,
            ClothCategoryId = createTemplateDto.ClothCategoryId,
            ArmTypeId = createTemplateDto.ArmTypeId,
            ClothGenderId = createTemplateDto.ClothGenderId,
            CollectionId = createTemplateDto.CollectionId,
            IsDeleted = false,
        };
        await _repository.Create(template);
        return new BaseResponse()
        {
            Message = "Template Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateTemplateDto updateTemplateDto)
    {
        var template = await _repository.GetById(id);
        if(template!= null)
        {
            template.StyleId = updateTemplateDto.StyleId;
            template.PatternId = updateTemplateDto.PatternId;
            template.MaterialId = updateTemplateDto.MaterialId;
            template.ColorId = updateTemplateDto.ColorId;
            template.ClothCategoryId = updateTemplateDto.ClothCategoryId;
            template.ArmTypeId = updateTemplateDto.ArmTypeId;
            template.ClothGenderId = updateTemplateDto.ClothGenderId;
            template.CollectionId = updateTemplateDto.CollectionId;
            await _repository.Update(template);
            return new BaseResponse()
            {
                Message = "Template Updated Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Update Template Successfully",
            Status = false
        };
    }
    public async Task<TemplateResponseModel> GetById(int id)
    {
        var template = await _repository.GetById(id);
        if(template != null)
        {
            var style = await _stylerepository.GetById(template.StyleId);
            var pattern = await _patternrepository.GetById(template.PatternId);
            var armType = await _armTyperepository.GetById(template.ArmTypeId);
            var color = await _colorrepository.GetById(template.ColorId);
            var material = await _materialrepository.GetById(template.MaterialId);
            var clothCategory = await _clothCategoryrepository.GetById(template.ClothCategoryId);
            var clothGender = await _clothGenderrepository.GetById(template.ClothGenderId);
            return new TemplateResponseModel()
            {
                Data = GetDetails(template, style, pattern, material, color, armType, clothCategory, clothGender),
                Message = "Template Retrieved Successfully",
                Status = true
            };
        }
        return new TemplateResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Template Successfully",
            Status = false
        };
    }
    public async Task<TemplatesResponseModel> GetByTemplateName(string TemplateName)
    {
        var templates = await _repository.GetByTemplateName(TemplateName);
        if (templates != null)
        {
            List<GetTemplateDto> TemplateList = new List<GetTemplateDto>();
            foreach (var template in templates)
            {
                var style = await _stylerepository.GetById(template.StyleId);
                var pattern = await _patternrepository.GetById(template.PatternId);
                var armType = await _armTyperepository.GetById(template.ArmTypeId);
                var color = await _colorrepository.GetById(template.ColorId);
                var material = await _materialrepository.GetById(template.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(template.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(template.ClothGenderId);
                TemplateList.Add(GetDetails(template, style, pattern, material, color, armType, clothCategory, clothGender));
            }
            return new TemplatesResponseModel()
            {
                Data = TemplateList,
                Message = "Template Retrieved Successfully",
                Status = true
            };
        }
        return new TemplatesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Template Successfully",
            Status = false
        };
    }
    public async Task<TemplatesResponseModel> GetTemplatesByClothCategory(int clothCategoryId)
    {
        var templates = await _repository.GetAllTemplatesByClothCategory(clothCategoryId);
        if (templates != null)
        {
            List<GetTemplateDto> TemplateList = new List<GetTemplateDto>();
            foreach (var template in templates)
            {
                var style = await _stylerepository.GetById(template.StyleId);
                var pattern = await _patternrepository.GetById(template.PatternId);
                var armType = await _armTyperepository.GetById(template.ArmTypeId);
                var color = await _colorrepository.GetById(template.ColorId);
                var material = await _materialrepository.GetById(template.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(template.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(template.ClothGenderId);
                TemplateList.Add(GetDetails(template, style, pattern, material, color, armType, clothCategory, clothGender));
            }
            return new TemplatesResponseModel()
            {
                Data = TemplateList,
                Message = "Templates List Retrieved Successfully",
                Status = true
            };
        }
        return new TemplatesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Templates List Successfully",
            Status = false
        };
    }
    public async Task<TemplatesResponseModel> GetTemplatesByClothCategoryClothGender(int clothCategoryId, int clothGenderId)
    {
        var templates = await _repository.GetAllTemplatesByClothCategoryClothGender(clothCategoryId, clothGenderId);
        if (templates != null)
        {
            List<GetTemplateDto> TemplateList = new List<GetTemplateDto>();
            foreach (var template in templates)
            {
                var style = await _stylerepository.GetById(template.StyleId);
                var pattern = await _patternrepository.GetById(template.PatternId);
                var armType = await _armTyperepository.GetById(template.ArmTypeId);
                var color = await _colorrepository.GetById(template.ColorId);
                var material = await _materialrepository.GetById(template.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(template.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(template.ClothGenderId);
                TemplateList.Add(GetDetails(template, style, pattern, material, color, armType, clothCategory, clothGender));
            }
            return new TemplatesResponseModel()
            {
                Data = TemplateList,
                Message = "Templates List Retrieved Successfully",
                Status = true
            };
        }
        return new TemplatesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Templates List Successfully",
            Status = false
        };
    }
    public async Task<TemplatesResponseModel> GetAllTemplates()
    {
        var templates = await _repository.GetAllTemplates();
        if(templates != null)
        {
            List<GetTemplateDto> TemplateList = new List<GetTemplateDto>();
            foreach (var template in templates)
            {
                var style = await _stylerepository.GetById(template.StyleId);
                var pattern = await _patternrepository.GetById(template.PatternId);
                var armType = await _armTyperepository.GetById(template.ArmTypeId);
                var color = await _colorrepository.GetById(template.ColorId);
                var material = await _materialrepository.GetById(template.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(template.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(template.ClothGenderId);
                TemplateList.Add(GetDetails(template, style, pattern, material, color, armType, clothCategory, clothGender));
            }
            return new TemplatesResponseModel()
            {
                Data = TemplateList,
                Message = "Templates List Retrieved Successfully",
                Status = true
            };
        }
        return new TemplatesResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Templates List Successfully",
            Status = false
        };
    }
    public GetTemplateDto GetDetails(Template template, Style style, Pattern pattern, Material material, Color color, ArmType armType, ClothCategory clothCategory, ClothGender clothGender)
    {
        return new GetTemplateDto()
        {
            Id = template.Id,
            TemplateId = template.TemplateId,
            TemplateName = template.TemplateName,
            GetCollectionDto = new GetCollectionDto()
            {
                CollectionName = template.Collection.CollectionName,
                ClothGender = clothGender.Gender,
                ClothCategory = clothCategory.ClothName
            },
            GetStyleDto = new GetStyleDto()
            {
                StyleId = style.StyleId,
                StyleName = style.StyleName,
                StyleUrl = style.StyleUrl,
                StylePrice = style.StylePrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = clothCategory.Id,
                    ClothName = clothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = clothGender.Id,
                    Gender = clothGender.Gender,
                }
            },
            GetPatternDto = new GetPatternDto()
            {
                Id = pattern.Id,
                PatternName = pattern.PatternName,
                PatternUrl = pattern.PatternUrl,
                PatternPrice = pattern.PatternPrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = clothCategory.Id,
                    ClothName = clothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = clothGender.Id,
                    Gender = clothGender.Gender,
                }
            },
            GetMaterialDto = new GetMaterialDto()
            {
                Id = material.Id,
                MaterialName = material.MaterialName,
                MaterialUrl = material.MaterialUrl,
                MaterialPrice = material.MaterialPrice,
            },
            GetColorDto = new GetColorDto()
            {
                Id = color.Id,
                ColorName = color.ColorName,
                ColorCode = color.ColorCode,
            },
            GetArmTypeDto = new GetArmTypeDto()
            {
                Id = armType.Id,
                ArmLength = armType.ArmLength
            },
            Price = style.StylePrice + pattern.PatternPrice + material.MaterialPrice,
        };
    }
    public async Task<DashBoardResponse> TemplatesDashboard()
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
            Message = "No Available Templates!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateTemplate(int id)
    {
        var template = await _repository.GetById(id);
        if(template != null)
        {
            template.IsDeleted = true;
            await _repository.Update(template);
            return new BaseResponse()
            {
                Message = "Template Deleted Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Delete Template Successfully",
            Status = false
        };
    }
}
