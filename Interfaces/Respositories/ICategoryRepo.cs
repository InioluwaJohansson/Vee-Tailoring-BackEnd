using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface ICategoryRepo : IRepo<Category>
    {
        Task<Category> GetById(int Id);
        Task<IList<Category>> List();
    }
}
