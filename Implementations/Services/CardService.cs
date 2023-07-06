using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;
public class CardService : ICardService
{
    ICardRepo _repository;
    IUserRepo _userRepo;
    public CardService(ICardRepo repository, IUserRepo userRepo)
    {
        _repository = repository;
        _userRepo = userRepo;
    }
    public async Task<BaseResponse> Create(CreateCardDto createCardDto)
    {
        var user = _userRepo.Get(x => x.Id == createCardDto.UserId && x.IsDeleted == false);
        if (user == null )
        {
             var card = new Card()
            {
                UserId = createCardDto.UserId,
                CardPin = createCardDto.CardPin,
                expiryMonth = createCardDto.ExpiryMonth,
                expiryYear = createCardDto.ExpiryYear,
                CVV = createCardDto.CVV,
                IsDeleted = false
            };
            await _repository.Create(card);
            return new BaseResponse()
            {
                Message = "Card Successfully Added",
                Status = true,
            };   
        }
        return new BaseResponse()
        {
            Message = "Unable To Add Card Successfully",
            Status = false,
        };
    }
    public async Task<CardsResponseModel> GetByUserId(int id)
    {
        var cards = await _repository.GetByExpression(x => x.UserId == id);
        if (cards != null)
        {
            return new CardsResponseModel()
            {
                Data = cards.Select(card => new GetCardDto{
                    Id = card.Id,
                    CardPin = card.CardPin.Substring(0, 2) + "************" + card.CardPin.Substring(14, 16),
                }).ToList(),
                Message = "Cards Found",
                Status = true
            };
        }
        return new CardsResponseModel()
        {
            Data = null,
            Message = "No Card Yet",
            Status = false
        };
    }
    public async Task<BaseResponse> DeActivateCard(int id, int UserId)
    {
        var response = await _repository.Get(x => x.Id == id && x.UserId == UserId);
        if (response != null)
        {
            response.IsDeleted = true;
            await _repository.Update(response);
            return new BaseResponse()
            {
                Message = "Card Removed Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Remove Successfully",
                Status = false
            };
        }
    }
}
