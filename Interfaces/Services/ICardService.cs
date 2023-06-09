using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services
{
    public interface ICardService
    {
        Task<BaseResponse> Create(CreateCardDto createCardDto);
        Task<CardsResponseModel> GetByUserId(int id);
        Task<BaseResponse> DeActivateCard(int id, int UserId);
    }
}
