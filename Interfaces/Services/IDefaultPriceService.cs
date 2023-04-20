using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Interfaces.Services;

public interface IDefaultPriceService
{
    Task<BaseResponse> Create(CreateDefaultPriceDto createDefaultPriceDto);
    Task<BaseResponse> Update(int id, UpdateDefaultPriceDto updateDefaultPriceDto);
    Task<DefaultPriceResponseModel> GetById(int id);
    Task<DefaultPricesResponseModel> GetAllDefaultPrices();
}
