using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.Enums;
namespace Vee_Tailoring.Models.DTOs;

public class CreateOrderDto
{
    public int ClothGenderId { get; set; }
    public int ClothCategory { get; set; }
    public OrderPerson OrderPerson { get; set; }
    public string OtherDetails { get; set; }
    public IFormFile image { get; set; }
    public decimal Pieces { get; set; }
    public CreateOrderAddressDto CreateOrderAddressDto { get; set; }
    public CreateOrderMeasurementDto CreateOrderMeasurementDto { get; set; }
    public int CustomerId { get; set; }
    public int StyleId { get; set; }
    public int PatternId { get; set; }
    public int ColorId { get; set; }
    public int MaterialId { get; set; }
    public int ArmTypeId { get; set; }
}
public class GetOrderDto
{
    public int Id { get; set; }
    public string OrderId { get; set; }
    public GetClothGenderDto GetClothGenderDto { get; set; }
    public GetClothCategoryDto GetClothCategoryDto { get; set; }
    public OrderPerson OrderPerson { get; set; }
    public decimal Price { get; set; }
    public decimal Pieces { get; set; }
    public GetCustomerDto GetCustomerDto { get; set; }
    public GetOrderAddressDto GetOrderAddressDto { get; set; }
    public GetStyleDto GetStyleDto { get; set; }
    public GetOrderMeasurementDto GetOrderMeasurementDto { get; set; }
    public GetPatternDto GetPatternDto { get; set; }
    public GetColorDto GetColorDto { get; set; }
    public GetMaterialDto GetMaterialDto { get; set; }
    public GetArmTypeDto GetArmTypeDto { get; set; }
    public GetStaffDto GetStaffDto { get; set; }
    public string CompletionTime { get; set; }
    public string OtherDetails { get; set; }
    public string ReferenceNumber { get; set; }
    public IsCompleted IsCompleted { get; set; }
    public IsPaid IsPaid { get; set; }
    public bool IsAssigned { get; set; }
}
public class UpdateStaffOrderDto{
    public int StaffId { get; set; }
    public bool IsAssigned { get; set; }
    public IsCompleted IsCompleted { get; set; }
}
public class UpdateOrderDto
{
    public int ClothGenderId { get; set; }
    public int ClothCategory { get; set; }
    public IFormFile image { get; set; }
    public OrderPerson OrderPerson { get; set; }
    public decimal Pieces { get; set; }
    public UpdateOrderAddressDto UpdateOrderAddressDto { get; set; }
    public int StyleId { get; set; }
    public UpdateOrderMeasurementDto UpdateOrderMeasurementDto { get; set; }
    public int PatternId { get; set; }
    public int ColorId { get; set; }
    public int MaterialId { get; set; }
    public int ArmTypeId { get; set; }
    public string OtherDetails { get; set; }
}
public class OrderResponseModel : BaseResponse
{
    public GetOrderDto Data { get; set; }
}
public class OrdersResponseModel : BaseResponse
{
    public ICollection<GetOrderDto> Data { get; set; } = new HashSet<GetOrderDto>();
}
