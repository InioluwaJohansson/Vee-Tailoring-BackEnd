namespace Vee_Tailoring.Models.DTOs;

public class PaystackData
{
    public string authorization_url { get; set; }
    public string access_code { get; set; }
    public string reference { get; set; }
}
public class PayStackPackage
{
    public string currency { get; set; }
    public decimal amount { get; set; }
    public string email { get; set; }
    public string referenceNumber { get; set; }

}
public class VisaData
{

}
public class PaymentMethodsDto : BaseResponse
{
    public PaystackData PaystackData { get; set; }
    public VisaData VisaData { get; set; }
}
public class VisaResponse : BaseResponse
{

}
