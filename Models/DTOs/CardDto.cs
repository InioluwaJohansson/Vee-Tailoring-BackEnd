using Vee_Tailoring.Entities;

namespace Vee_Tailoring.Models.DTOs;
public class CreateCardDto
{
    public string CardPin { get; set; }
    public int UserId { get; set; }
    public string ValidTHRU { get; set; }
    public string CVV { get; set; }
}
public class GetCardDto
{
    public int Id { get; set; }
    public string CardPin { get; set; }
}
public class CardsResponseModel : BaseResponse
{
    public ICollection<GetCardDto> Data { get; set; } = new HashSet<GetCardDto>();
}