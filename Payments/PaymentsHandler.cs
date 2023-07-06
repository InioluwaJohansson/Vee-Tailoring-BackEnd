using Aspose.Words.Drawing.Charts;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Payments;
public class PaymentsHandler : IPaymentsHandler
{
    IConfiguration _configuration;
    HttpClient _httpClient;
    HttpResponseMessage _response;
    public PaymentsHandler(IConfiguration configuration, HttpClient httpClient, HttpResponseMessage response)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _response = response;
    }
    public async Task<HttpStatusCode> PaystackPayment(PayStackPackage package)
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //HttpResponseMessage catchresponse = new HttpResponseMessage();
        var url = "https://api.paystack.co/transaction/initialize";
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["PayStack:ApiKey"]);
        var content = new StringContent(JsonSerializer.Serialize(new
        {
            currency = package.currency,
            amount = package.amount,
            email = package.email,
            referenceNumber = package.referenceNumber
        }), Encoding.UTF8, "application/json");
        _response = await _httpClient.PostAsync(url, content);
        var reString = await _response.Content.ReadAsStringAsync();
        var responseObj = JsonSerializer.Deserialize<PaymentMethodsDto>(reString);
        return _response.StatusCode;
    }
    public async Task<HttpStatusCode> VisaPayment(Card card, decimal amount)
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //HttpResponseMessage catchresponse = new HttpResponseMessage();
        _httpClient.DefaultRequestHeaders.Add("X-ApiKey", _configuration["Visa:ApiKey"]);
        _httpClient.DefaultRequestHeaders.Add("X-ApiSecret", _configuration["Visa:ApiSecret"]);
        var content = new StringContent(JsonSerializer.Serialize(new
        {
            cardNumber = card.CardPin,
            expiryMonth = card.expiryMonth,
            expiryYear = card.expiryYear,
            cvv = card.CVV,
            amount
        }), Encoding.UTF8, "application/json");
        _response = await _httpClient.PostAsync("https://api.visa.com/payments", content);
        return _response.StatusCode;
    }
}
