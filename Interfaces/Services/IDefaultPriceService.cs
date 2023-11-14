using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Interfaces.Services;

public interface IDefaultPriceService
{
    Task<BaseResponse> Create(CreateDefaultPriceDto createDefaultPriceDto);
    Task<BaseResponse> Update(int id, UpdateDefaultPriceDto updateDefaultPriceDto);
    Task<BaseResponse> SetPrices(int id, int updateId);
    Task<DefaultPriceResponseModel> GetById(int id);
    Task<DefaultPricesResponseModel> GetAllDefaultPrices();
}
