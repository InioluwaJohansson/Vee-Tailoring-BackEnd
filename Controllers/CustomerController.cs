using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class CustomerController : Controller
{
    ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    // POST : AddCustomer
    [HttpPost("CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromForm] CreateCustomerDto createCustomerDto)
    {
        var customer = await _customerService.Create(createCustomerDto);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // PUT : UpdateCustomer
    [HttpPut("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromForm] UpdateCustomerDto updateCustomerDto)
    {
        //id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var customer = await _customerService.Update(id, updateCustomerDto);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : GetCustomerById
    [HttpGet("GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetById(id);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : GetCustomerByUserId
    [HttpGet("GetCustomerByUserId")]
    public async Task<IActionResult> GetByUserId(int UserId)
    {
        //string claim = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //int id = int.Parse(claim);
        var customer = await _customerService.GetByUserId(UserId);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : GetCustomerByCustomerEmail
    [HttpGet("GetCustomerByCustomerEmail")]
    public async Task<IActionResult> GetCustomerByEmail(string email)
    {
        var customer = await _customerService.GetByCustomerEmail(email);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : GetAllCustomers
    [HttpGet("GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customer = await _customerService.GetAllCustomers();
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : CustomerDashboard
    [HttpGet("CustomerDashBoard")]
    public async Task<IActionResult> CustomerDashBoard()
    {
        var customer = await _customerService.CustomerDashboard();
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : CustomerUserDashboard
    [HttpGet("CustomerUserDashBoard")]
    public async Task<IActionResult> CustomerUserDashBoard(int UserId)
    {
        var customer = await _customerService.UserDashboard(UserId);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }

    // GET : DeleteCustomer
    [HttpPut("DeActivateCustomer")]
    public async Task<IActionResult> DeActivateCustomer(int id)
    {
        var customer = await _customerService.DeActivateCustomer(id);
        if (customer.Status == true)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }
}
