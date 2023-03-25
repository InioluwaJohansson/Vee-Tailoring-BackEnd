using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IArmTypeRepo: IRepo<ArmType>
    {
        Task<ArmType> GetById(int Id);
        Task<IList<ArmType>> List();
    }
}
