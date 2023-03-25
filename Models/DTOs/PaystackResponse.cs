namespace V_Tailoring.Models.DTOs
{
    public class PaystackData
    {
        public string authorization_url { get; set; }
        public string access_code { get; set; }
        public string reference { get; set; }
    }
    public class PaystackResponse : BaseResponse
    {
        public PaystackData PaystackData { get; set; }
    }
}
