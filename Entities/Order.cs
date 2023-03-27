using V_Tailoring.Contracts;
using V_Tailoring.Models.Enums;
namespace V_Tailoring.Entities
{
    public class Order: AuditableEntity
    {
        public string OrderId { get; set; }
        public ClothGender ClothGender { get; set; }
        public int ClothGenderId { get; set; }
        public ClothCategory ClothType { get; set; }
        public int ClothCategoryId { get; set; }
        public OrderPerson OrderPerson { get; set; }
        public decimal Price { get; set; }
        public decimal Pieces { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public int OrderAddressId { get; set; }
        public Style Style { get; set; }
        public int StyleId { get; set; }
        public OrderMeasurement OrderMeasurements { get; set; }
        public int OrderMeasurementId { get; set; }
        public Pattern Pattern { get; set; }
        public int PatternId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public ArmType ArmType { get; set; }
        public int ArmTypeId { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }
        public string OtherDetails { get; set; }
        public string ReferenceNumber { get; set; } = "";
        public DateTime CompletionTime { get; set; }
        public IsCompleted IsCompleted { get; set; }
        public IsPaid IsPaid { get; set; }
        public bool AddToCart { get; set; }
        public bool IsAssigned { get; set; }
    }
}
