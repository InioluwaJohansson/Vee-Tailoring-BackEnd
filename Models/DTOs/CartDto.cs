﻿namespace Vee_Tailoring.Models.DTOs;

public class GetCartDto
{
    public List<GetOrderDto> GetOrderDtos { get; set; } = new List<GetOrderDto>();
    public decimal TotalPrice { get; set; }
}
public class CartResponseModel : BaseResponse
{
    public GetCartDto Data { get; set; }
}
