using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Security.AccessControl;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class TemplateService : ITemplateService
{
    ITemplateRepo _repository;
    public TemplateService(ITemplateRepo repository)
    {
        _repository = repository;
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
            return new TemplateResponseModel()
            {
                Data = GetDetails(template),
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
            foreach (var template in templates)     TemplateList.Add(GetDetails(template));
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
            foreach (var template in templates)     TemplateList.Add(GetDetails(template));
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
            foreach (var template in templates)     TemplateList.Add(GetDetails(template));
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
            foreach (var template in templates)     TemplateList.Add(GetDetails(template));
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
    public GetTemplateDto GetDetails(Template template)
    {
        return new GetTemplateDto()
        {
            Id = template.Id,
            TemplateId = template.TemplateId,
            TemplateName = template.TemplateName,
            GetCollectionDto = new GetCollectionDto()
            {
                CollectionName = template.Collection.CollectionName,
                ClothGender = template.ClothGender.Gender,
                ClothCategory = template.ClothCategory.ClothName
            },
            GetStyleDto = new GetStyleDto()
            {
                StyleId = template.Style.StyleId,
                StyleName = template.Style.StyleName,
                StyleUrl = template.Style.StyleUrl,
                StylePrice = template.Style.StylePrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = template.ClothCategory.Id,
                    ClothName = template.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = template.ClothGender.Id,
                    Gender = template.ClothGender.Gender,
                }
            },
            GetPatternDto = new GetPatternDto()
            {
                Id = template.Pattern.Id,
                PatternName = template.Pattern.PatternName,
                PatternUrl = template.Pattern.PatternUrl,
                PatternPrice = template.Pattern.PatternPrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = template.ClothCategory.Id,
                    ClothName = template.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = template.ClothGender.Id,
                    Gender = template.ClothGender.Gender,
                }
            },
            GetMaterialDto = new GetMaterialDto()
            {
                Id = template.Material.Id,
                MaterialName = template.Material.MaterialName,
                MaterialUrl = template.Material.MaterialUrl,
                MaterialPrice = template.Material.MaterialPrice,
            },
            GetColorDto = new GetColorDto()
            {
                Id = template.Color.Id,
                ColorName = template.Color.ColorName,
                ColorCode = template.Color.ColorCode,
            },
            GetArmTypeDto = new GetArmTypeDto()
            {
                Id = template.ArmType.Id,
                ArmLength = template.ArmType.ArmLength
            },
            Price = template.Style.StylePrice + template.Pattern.PatternPrice + template.Material.MaterialPrice,
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
