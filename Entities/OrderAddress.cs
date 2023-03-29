using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class OrderAddress : AuditableEntity
{
    public string NumberLine { get; set; } = "";
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string Region { get; set; } = "";
    public string State { get; set; } = "";
    public string Country { get; set; } = "";
    public string PostalCode { get; set; } = "";
}
