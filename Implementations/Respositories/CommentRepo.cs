using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class CommentRepo : BaseRepository<Comment>, ICommentRepo
{
    public CommentRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Comment> GetById(int Id)
    {
        return await context.Comments.Include(c => c.Post).Include(c => c.Customer).Include(c => c.Customer.UserDetails).SingleOrDefaultAsync(c => c.Id == Id);
    }
    public async Task<IList<Comment>> GetByPostId(int commentPostId)
    {
        return await context.Comments.Include(c => c.Post).Include(c => c.Customer).Include(c => c.Customer.UserDetails).Where(c => c.Post.Id == commentPostId && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Comment>> GetByPostTitle(string commentPostTitle)
    {
        return await context.Comments.Include(c => c.Post).Include(c => c.Customer).Include(c => c.Customer.UserDetails).Where(c => c.Post.PostTitle == commentPostTitle && c.IsDeleted == false).ToListAsync();
    }
}

