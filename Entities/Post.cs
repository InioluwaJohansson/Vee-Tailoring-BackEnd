using Vee_Tailoring.Contracts;
namespace Vee_Tailoring.Entities;

public class Post: AuditableEntity
{
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public string PostTitle { get; set; }
    public string PostImage { get; set; }
    public string PostDescription { get; set; }
    public DateTime PublishDate { get; set; }
    public int ReadTime { get; set; }
    public int Likes { get; set; }
    public Staff Staff { get; set; }
    public int StaffId  { get; set; }
    public bool IsApproved { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
}
