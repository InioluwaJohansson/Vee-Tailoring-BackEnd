using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Interface.Services
{
    public interface IDefaultPriceService
    {
        Task<BaseResponse> Create(CreateDefaultPriceDto createDefaultPriceDto);
        Task<BaseResponse> Update(int id, UpdateDefaultPriceDto updateDefaultPriceDto);
        Task<DefaultPriceResponseModel> GetById(int id);
        Task<DefaultPricesResponseModel> GetAllDefaultPrices();
    }
}
