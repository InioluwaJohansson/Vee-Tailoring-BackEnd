using V_Tailoring.Models.DTOs;
using V_Tailoring.Models.Enums;
using Vee_Tailoring.Models.DTOs;

namespace V_Tailoring.Interface.Services
{
    public interface IOrderService
    {
        Task<BaseResponse> Create(CreateOrderDto createOrderDto);
        Task<BaseResponse> Update(int id, UpdateOrderDto updateOrderDto);
        Task<BaseResponse> UpdatePayment(UpdateOrderPaymentCheck updateOrderPayment);
        Task<BaseResponse> AddRemoveFromCart(int id);
        Task<OrderResponseModel> GetOrderById(int id);
        Task<OrdersResponseModel> GetOrderByOrderNo(string OrderNo);
        Task<OrdersResponseModel> GetOrdersByCustomerId(int id);
        Task<OrdersResponseModel> GetOrdersByCustomerUserId(int id);
        Task<CartResponseModel> GetCartOrdersByCustomerId(int id);
        Task<OrdersResponseModel> GetOrderByCustomerIdIsPaid(int id, IsPaid IsPaid);
        Task<OrdersResponseModel> GetOrderByCustomerUserIdOrderNo(int UserId, string OrderNo);
        Task<OrdersResponseModel> GetAllOrdersByIsPaid(IsPaid isPaid);
        Task<OrdersResponseModel> GetAllOrdersByIsCompleted(IsCompleted isCompleted);
        Task<OrdersResponseModel> GetOrdersByStaffId(int id);
        Task<OrdersResponseModel> GetOrdersByStaffUserId(int id);
        Task<OrdersResponseModel> GetOrdersByStaffIdIsCompleted(int id, IsCompleted IsCompleted);
        Task<BaseResponse> AssignAnOrder(int id, int staffId, DateTime date);
        Task<OrdersResponseModel> GetAllUnAssignedOrders();
        Task<OrdersResponseModel> GetAllAssignedOrders();
        Task<OrdersResponseModel> GetAllOrders();
        Task<OrderDashboard> OrdersDashboard();
        Task<BaseResponse> DeActivateOrder(int id);
    }
}
