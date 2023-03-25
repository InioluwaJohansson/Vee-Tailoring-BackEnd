using V_Tailoring.Entities;

namespace V_Tailoring.Interfaces.Respositories
{
    public interface ITemplateRepo : IRepo<Template>
    {
        Task<Template> GetById(int Id);
        Task<IList<Template>> GetAllTemplatesByClothCategory(int clothCategory);
        Task<IList<Template>> GetAllTemplatesByClothCategoryClothGender(int clothCategory, int clothGender);
        Task<IList<Template>> GetAllTemplatesByCollectionId(int id);
        Task<IList<Template>> GetAllTemplates();
        Task<IList<Template>> GetByTemplateName(string TemplateName);
    }
}
