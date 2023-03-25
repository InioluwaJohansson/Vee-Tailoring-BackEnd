using V_Tailoring.Contracts;
namespace V_Tailoring.Entities
{
    public class Comment: AuditableEntity
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string Comments { get; set; }
        public int Likes { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
