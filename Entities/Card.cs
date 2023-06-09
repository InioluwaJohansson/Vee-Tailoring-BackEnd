using Vee_Tailoring.Contracts;

namespace Vee_Tailoring.Entities;
public class Card : AuditableEntity
{
    public string CardPin { get; set; }
    public int UserId { get; set; }
    public Customer customer { get; set; }
    public string ValidTHRU { get; set; }
    public string CVV { get; set; }
}
