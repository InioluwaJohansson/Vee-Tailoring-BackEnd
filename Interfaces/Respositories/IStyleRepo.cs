using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IStyleRepo : IRepo<Style>
    {
        Task<Style> GetById(int Id);
        Task<IList<Style>> GetByStyleName(string styleName);
        Task<IList<Style>> GetByClothCategory(int categoryId);
        Task<IList<Style>> GetByClothCategoryGender(int categoryId, int clothGenderId);
        Task<IList<Style>> GetByStylePrice(decimal price);
        Task<IList<Style>> List();
    }
}
