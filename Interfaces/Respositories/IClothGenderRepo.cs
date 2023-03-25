using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IClothGenderRepo : IRepo<ClothGender>
    {
        Task<ClothGender> GetById(int Id);
        Task<IList<ClothGender>> List();
    }
}
