namespace Vee_Tailoring.Entities;

public class Cart
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
    public decimal Price { get; set; }
}
