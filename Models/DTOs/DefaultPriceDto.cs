namespace Vee_Tailoring.Models.DTOs;

public class CreateDefaultPriceDto
{
    public string PriceName { get; set; }
    public decimal Price { get; set; }
}
public class GetDefaultPriceDto
{
    public int Id { get; set; }
    public string PriceName { get; set; }
    public decimal Price { get; set; }
}
public class UpdateDefaultPriceDto
{
    public string PriceName { get; set; }
    public decimal Price { get; set; }
}
public class DefaultPriceResponseModel : BaseResponse
{
    public GetDefaultPriceDto Data { get; set; }
}
public class DefaultPricesResponseModel : BaseResponse
{
    public ICollection<GetDefaultPriceDto> Data { get; set; } = new HashSet<GetDefaultPriceDto>();
}
