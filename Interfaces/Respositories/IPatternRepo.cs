using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IPatternRepo : IRepo<Pattern>
    {
        Task<Pattern> GetById(int Id);
        Task<IList<Pattern>> GetByName(string PatternName);
        Task<IList<Pattern>> GetPatternByClothCategory(int clothCategory);
        Task<IList<Pattern>> GetPatternByClothCategoryGender(int clothCategoryId, int clothGenderId);
        Task<IList<Pattern>> GetPatternByPrice(decimal price);
        Task<IList<Pattern>> List();
    }
}
