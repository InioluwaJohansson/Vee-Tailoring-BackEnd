﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums.V_Tailoring.Models.Enums;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    // POST : Addpayment
    [HttpPost("MakePayment")]
    public async Task<IActionResult> MakePayment(int id, PaymentMethod method)
    {
        var payment = await _paymentService.MakePayment(id, method);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }

    // PUT : Updatepayment
    [HttpGet("VerifyPayment")]
    public async Task<IActionResult> VerifyPayment(string referenceNo)
    {
        var payment = await _paymentService.VerifyPayment(referenceNo);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }
    // GET : GetpaymentById
    [HttpGet("GetPaymentById")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payment = await _paymentService.GetPayment(id);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }
    // PUT : Updatepayment
    [HttpGet("GetAllPaymentsByCustomerUserId")]
    public async Task<IActionResult> GetAllPaymentsByCustomerUserId(int id)
    {
        var payment = await _paymentService.GetAllPaymentsByCustomer(id);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }
    // PUT : Updatepayment
    [HttpPut("VerifyPaymentByCustomerUserId")]
    public async Task<IActionResult> VerifyPaymentByCustomerUserID(int id, string referenceNo)
    {
        var payment = await _paymentService.VerifyPaymentByCustomer(id, referenceNo);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }

    // GET : GetAllpayments
    [HttpGet("GetAllPayments")]
    public async Task<IActionResult> GetAllPayments()
    {
        var payment = await _paymentService.GetAllPayments();
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }
    // GET : GetpaymentById
    [HttpGet("GenerateInvoice")]
    public async Task<IActionResult> GenerateInvoice(int id)
    {
        var payment = await _paymentService.GenerateInvoice(id);
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }
    // GET : paymentsDashboard
    /*[HttpGet("PaymentsDashBoard")]
    public async Task<IActionResult> PaymentsDashBoard()
    {
        var payment = await _paymentService.paymentDashboard();
        if (payment.Status == true)
        {
            return Ok(payment);
        }
        return BadRequest(payment);
    }*/
}