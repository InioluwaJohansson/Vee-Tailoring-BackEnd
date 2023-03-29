using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface ICategoryRepo : IRepo<Category>
{
    Task<Category> GetById(int Id);
    Task<IList<Category>> List();
}
