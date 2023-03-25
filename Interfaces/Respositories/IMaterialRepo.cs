using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IMaterialRepo : IRepo<Material>
    {
        Task<Material> GetById(int Id);
        Task<IList<Material>> GetByMaterialName(string MaterialName);
        Task<IList<Material>> ListByMaterialPrice(decimal MaterialPrice);
        Task<IList<Material>> List();
    }
}
