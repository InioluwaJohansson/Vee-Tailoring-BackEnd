using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IClothCategoryRepo : IRepo <ClothCategory>
    {
        Task<ClothCategory> GetById(int Id);
        Task<IList<ClothCategory>> List();
    }
}
