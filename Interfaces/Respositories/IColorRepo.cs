using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IColorRepo : IRepo <Color>
{
    Task<Color> GetById(int Id);
    Task<IList<Color>> GetbyColorName(string colorName);
    Task<IList<Color>> GetbyColorCode(string colorCode);
    Task<IList<Color>> List();
}
