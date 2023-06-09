using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.Enums;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IOrderRepo : IRepo<Order>
{
    Task<Order> GetOrderById(int Id);
    Task<IList<Order>> GetOrderbyOrderNo(string OrderNo);
    Task<IList<Order>> ListAllOrdersByCustomerId(int Id);
    Task<IList<Order>> ListAllOrdersByCustomerUserId(int id);
    Task<IList<Order>> ListAllOrdersByCustomerUserIdDate(int id, DateTime startdate, DateTime endDate);
    Task<IList<Order>> ListAllOrdersByCustomerIdIsPaid(int CustomerId, IsPaid IsPaid);
    Task<IList<Order>> GetOrderbyCustomerIdOrderNo(int id, string OrderNo);
    Task<IList<Order>> ListAllOrdersByIsPaid(IsPaid IsPaid);
    Task<IList<Order>> ListAllOrdersByIsCompleted(IsCompleted IsCompleted);
    Task<IList<Order>> ListAllOrdersByStaffId(int Id);
    Task<IList<Order>> ListAllOrdersByStaffUserId(int Id);
    Task<IList<Order>> ListAllOrdersByStaffIdIsCompleted(int Id, IsCompleted isCompleted);
    Task<IList<Order>> ListAllAssignedOrders();
    Task<IList<Order>> ListAllUnAssignedOrders();
    Task<IList<Order>> ListAllOrders();
}
