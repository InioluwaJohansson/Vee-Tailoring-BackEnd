using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IClothGenderRepo : IRepo<ClothGender>
{
    Task<ClothGender> GetById(int Id);
    Task<IList<ClothGender>> List();
}
