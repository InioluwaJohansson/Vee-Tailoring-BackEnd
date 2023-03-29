using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IDefaultPriceRepo : IRepo<DefaultPrice>
{
    Task<DefaultPrice> GetById(int id);
    Task<DefaultPrice> GetDefaultPrice();
    Task<DefaultPrice> GetShippingFees();
}
