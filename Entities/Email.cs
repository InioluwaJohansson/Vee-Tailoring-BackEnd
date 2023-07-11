using Vee_Tailoring.Contracts;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Entities;
public class Email : AuditableEntity
{
    public string ReceiverName { get; set; }
    public string ReceiverEmail { get; set; }
    public string Message { get; set; }
    public string Subject { get; set; }
    public string AttachmentUrl { get; set; }
    public int StaffId { get; set; }
    public EmailType EmailType { get; set; }
    public Staff Staff { get; set; }
}
