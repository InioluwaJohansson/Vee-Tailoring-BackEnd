namespace V_Tailoring.Models.DTOs
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
    public class DashBoardResponse : BaseResponse
    {
        public int Total { get; set; }
        public int Active { get; set; }
        public int InActive { get; set; }
    }
    public class OrderDashboard : BaseResponse
    {
        public int Total { get; set; }
        public int Assigned { get; set; }
        public int UnAssigned { get; set; }
        public int Completed { get; set; }
        public int UnCompleted { get; set; }
        public int Paid { get; set; }
        public int UnPaid { get; set;}
    }
    public class CustomerUserDashboard : BaseResponse
    {
        public int Total { get; set; }
        public int Paid { get; set; }
        public int UnPaid { get; set; }
    }
    public class StaffUserDashboard : BaseResponse
    {
        public int Total { get; set; }
        public int Assigned { get; set; }
        public int UnAssigned { get; set; }
        public int Completed { get; set; }
        public int UnCompleted { get; set; }
    }
}
