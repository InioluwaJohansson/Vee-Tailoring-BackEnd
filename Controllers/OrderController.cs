using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class OrderController : Controller
{
    IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    // POST : AddOrder
    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromForm] CreateOrderDto createOrderDto)
    {
        var order = await _orderService.Create(createOrderDto);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // PUT : UpdateOrder
    [HttpPut("UpdateOrder")]
    public async Task<IActionResult> UpdateOrder(int id, [FromForm] UpdateOrderDto updateOrderDto)
    {
        var order = await _orderService.Update(id, updateOrderDto);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // PUT : AddRemoveFromCart
    [HttpPut("AddRemoveFromCart")]
    public async Task<IActionResult> AddRemoveFromCart(int id)
    {
        var order = await _orderService.AddRemoveFromCart(id);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrderById
    [HttpGet("GetOrderById")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrderByOrderNo
    [HttpGet("GetOrderByOrderNo")]
    public async Task<IActionResult> GetOrderByOrderNo(string orderNo)
    {
        var order = await _orderService.GetOrderByOrderNo(orderNo);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrdersByCustomerUserId
    [HttpGet("GetOrdersByCustomerUserId")]
    public async Task<IActionResult> GetOrdersByCustomerUserId(int customerId)
    {
        var order = await _orderService.GetOrdersByCustomerUserId(customerId);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrdersByCustomerId
    [HttpGet("GetOrdersByCustomerId")]
    public async Task<IActionResult> GetOrdersByCustomerId(int id)
    {
        var order = await _orderService.GetOrdersByCustomerId(id);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetCartOrdersByCustomerId
    [HttpGet("GetCartOrdersByCustomerId")]
    public async Task<IActionResult> GetCartOrdersByCustomerId(int customerId)
    {
        var order = await _orderService.GetCartOrdersByCustomerId(customerId);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrderByCustomerIdIsPaid
    [HttpGet("GetOrderByCustomerIdIsPaid")]
    public async Task<IActionResult> GetOrderByCustomerIdIsPaid(IsPaid IsPaid, int customerId)
    {
        var order = await _orderService.GetOrderByCustomerIdIsPaid(customerId, IsPaid);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrderByCustomerIdOrderNo
    [HttpGet("GetOrderByCustomerIdOrderNo")]
    public async Task<IActionResult> GetOrderByCustomerUserIdIsOrderNo(int customerId, string OrderNo)
    {
        var order = await _orderService.GetOrderByCustomerUserIdOrderNo(customerId, OrderNo);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllUnAssignedOrders
    [HttpGet("GetAllUnAssignedOrders")]
    public async Task<IActionResult> GetAllUnAssignedOrders()
    {
        var order = await _orderService.GetAllUnAssignedOrders();
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllOrdersByIsPaid
    [HttpGet("GetAllOrdersByIsPaid")]
    public async Task<IActionResult> GetAllOrdersByIsPaid(IsPaid isPaid)
    {
        var order = await _orderService.GetAllOrdersByIsPaid(isPaid);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllOrdersByIsCompleted
    [HttpGet("GetAllOrdersByIsCompleted")]
    public async Task<IActionResult> GetAllOrdersByIsCompleted(IsCompleted isCompleted)
    {
        var order = await _orderService.GetAllOrdersByIsCompleted(isCompleted);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllAssignedOrders
    [HttpGet("GetAllAssignedOrders")]
    public async Task<IActionResult> GetAllAssignedOrders()
    {
        var order = await _orderService.GetAllAssignedOrders();
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllOrders
    [HttpGet("GetAllOrders")]
    public async Task<IActionResult> GetAllOrders()
    {
        var order = await _orderService.GetAllOrders();
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrdersByStaffUserId
    [HttpGet("GetOrdersByStaffUserId")]
    public async Task<IActionResult> GetOrdersByStaffUserId(int staffId)
    {
        var order = await _orderService.GetOrdersByStaffUserId(staffId);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllOrders
    [HttpGet("GetOrdersByStaffId")]
    public async Task<IActionResult> GetOrdersByStaffId(int id)
    {
        var order = await _orderService.GetOrdersByStaffId(id);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetOrdersByStaffIdIsCompleted
    [HttpGet("GetOrdersByStaffIdIsCompleted")]
    public async Task<IActionResult> GetOrdersByStaffIdIsCompleted(int staffId, IsCompleted IsCompleted)
    {
        var order = await _orderService.GetOrdersByStaffIdIsCompleted(staffId, IsCompleted);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : AssignAnOrder
    [HttpPut("AssignAnOrder")]
    public async Task<IActionResult> AssignAnOrder(int staffId, int id, DateTime completionTime)
    {
        var order = await _orderService.AssignAnOrder(id, staffId, completionTime);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }
    // GET : OrderDashboard
    [HttpGet("OrderDashBoard")]
    public async Task<IActionResult> OrderDashBoard()
    {
        var order = await _orderService.OrdersDashboard();
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }

    // GET : GetAllOrders
    [HttpGet("DeActivateOrder")]
    public async Task<IActionResult> DeActivateOrder(int id)
    {
        var order = await _orderService.DeActivateOrder(id);
        if (order.Status == true)
        {
            return Ok(order);
        }
        return BadRequest(order);
    }
}
