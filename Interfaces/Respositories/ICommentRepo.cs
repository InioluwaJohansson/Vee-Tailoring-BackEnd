using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface ICommentRepo : IRepo<Comment>
{
    Task<Comment> GetById(int Id);
    Task<IList<Comment>> GetByPostId(int commentPostId);
    Task<IList<Comment>> GetByPostTitle(string commentPostTitle);
}

