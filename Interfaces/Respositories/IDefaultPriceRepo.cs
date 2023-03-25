using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IDefaultPriceRepo : IRepo<DefaultPrice>
    {
        Task<DefaultPrice> GetById(int id);
        Task<DefaultPrice> GetDefaultPrice();
        Task<DefaultPrice> GetShippingFees();
    }
}
