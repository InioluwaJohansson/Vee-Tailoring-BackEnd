using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Implementations.Services
{
    public class DefaultPriceService : IDefaultPriceService
    {
        IDefaultPriceRepo _repository;
        public DefaultPriceService(IDefaultPriceRepo repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse> Create(CreateDefaultPriceDto createDefaultPriceDto)
        {
            var clothDefaultPrice = new DefaultPrice()
            {
                PriceName = createDefaultPriceDto.PriceName,
                Price = createDefaultPriceDto.Price,
                IsDeleted = false,
            };
            await _repository.Create(clothDefaultPrice);
            return new BaseResponse()
            {
                Message = "Price Retrived Successfully",
                Status = true
            };
        }
        public async Task<BaseResponse> Update(int id, UpdateDefaultPriceDto updateDefaultPriceDto)
        {
            var updatedDefaultPrice = await _repository.GetById(id);
            if (updatedDefaultPrice != null)
            {
                updatedDefaultPrice.PriceName = updateDefaultPriceDto.PriceName ?? updatedDefaultPrice.PriceName;
                updatedDefaultPrice.Price = updateDefaultPriceDto.Price;
                await _repository.Update(updatedDefaultPrice);
                return new BaseResponse()
                {
                    Message = "Price Updated Successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Failed To Update Price",
                    Status = false
                };
            }
        }
        public async Task<DefaultPriceResponseModel> GetById(int id)
        {
            var clothDefaultPrice = await _repository.GetById(id);
            if (clothDefaultPrice != null)
            {
                return new DefaultPriceResponseModel()
                {
                    Data = GetDetails(clothDefaultPrice),
                    Message = "Price Retrived Successfully",
                    Status = true
                };
            }
            else
            {
                return new DefaultPriceResponseModel()
                {
                    Data = null,
                    Message = "Unable To Retrieve Price",
                    Status = false
                };
            }
        }
        public async Task<DefaultPricesResponseModel> GetAllDefaultPrices()
        {
            var clothDefaultPrice = await _repository.GetAll();
            if (clothDefaultPrice != null)
            {

                return new DefaultPricesResponseModel()
                {
                    Data = clothDefaultPrice.Select(x => GetDetails(x)).ToList(),
                    Message = "Price Retrived Successfully",
                    Status = true
                };
            }
            else
            {
                return new DefaultPricesResponseModel()
                {
                    Data = null,
                    Message = "Unable To Retrieve PriceList",
                    Status = false
                };
            }
        }
        public GetDefaultPriceDto GetDetails(DefaultPrice clothDefaultPrice)
        {
            return new GetDefaultPriceDto
            {
                Price = clothDefaultPrice.Price,
            };
        }
    }
}