namespace Vee_Tailoring.Models.DTOs;

public class PaystackData
{
    public string authorization_url { get; set; }
    public string access_code { get; set; }
    public string reference { get; set; }
}
public class PayPalData
{

}
public class PaymentMethodsDto : BaseResponse
{
    public PaystackData PaystackData { get; set; }
    public PayPalData PayPalData { get; set; }
}
public class PaypalResponse : BaseResponse
{

}
