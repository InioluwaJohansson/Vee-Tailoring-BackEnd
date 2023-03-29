using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interface.Services;

public interface ITemplateService
{
    Task<BaseResponse> Create(CreateTemplateDto createTemplateDto);
    Task<BaseResponse> Update(int id, UpdateTemplateDto updateTemplateDto);
    Task<TemplateResponseModel> GetById(int id);
    Task<TemplatesResponseModel> GetByTemplateName(string templateId);
    Task<TemplatesResponseModel> GetTemplatesByClothCategory(int templateId);
    Task<TemplatesResponseModel> GetTemplatesByClothCategoryClothGender(int clothCategory, int clothGender);
    Task<TemplatesResponseModel> GetAllTemplates();
    Task<DashBoardResponse> TemplatesDashboard();
    Task<BaseResponse> DeActivateTemplate(int id);
}
