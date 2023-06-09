using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Respositories;

public class OrderRepo : BaseRepository<Order>, IOrderRepo
{
    public OrderRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Order> GetOrderById(int Id)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Order>> GetOrderbyOrderNo(string OrderNo)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).Where(c => c.OrderId.StartsWith($"ORDER{OrderNo}") && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByCustomerId(int id)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Customer.Id == id && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByCustomerUserId(int id)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Customer.User.Id == id && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByCustomerUserIdDate(int id, DateTime startdate, DateTime endDate)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Customer.User.Id == id && c.CreatedOn >= startdate && c.CreatedOn <= endDate && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByCustomerIdIsPaid(int id, IsPaid IsPaid)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Customer.User.Id == id && c.IsPaid == IsPaid && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> GetOrderbyCustomerIdOrderNo(int id, string OrderNo)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Customer.User.Id == id && c.OrderId.StartsWith($"ORDER{OrderNo}") && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByStaffId(int id)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Staff.Id == id && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByStaffUserId(int id)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Staff.User.Id == id && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByStaffIdIsCompleted(int id, IsCompleted IsCompleted)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.Staff.User.Id == id && c.IsCompleted == IsCompleted && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByIsPaid(IsPaid IsPaid)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.IsPaid == IsPaid && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrdersByIsCompleted(IsCompleted IsCompleted)
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.IsCompleted == IsCompleted && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllAssignedOrders()
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.IsAssigned == true && c.IsCompleted == IsCompleted.Pending && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllUnAssignedOrders()
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.IsAssigned == false && c.IsCompleted == IsCompleted.Pending && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Order>> ListAllOrders()
    {
        return await context.Orders.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Include(c => c.Staff.UserDetails.Address).Include(c => c.OrderMeasurements).Include(c => c.OrderAddress).Include(c => c.ClothCategory).Include(c => c.ClothGender).Include(c => c.ArmType).Include(c => c.Material).Include(c => c.Color).Include(c => c.Style).Include(c => c.Pattern).OrderByDescending(c => c.CreatedOn).Where(c => c.IsDeleted == false).ToListAsync();
    }
}
