using Vee_Tailoring.Contracts;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Entities;
public class Token : AuditableEntity
{
    public string TokenNo { get; set; }
    public int UserId { get; set; }
    public TokenType TokenType { get; set; }
    public DateTime TokenStartTime { get; set; }
    public DateTime TokenEndTime { get; set; }
}

