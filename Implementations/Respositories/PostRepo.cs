﻿using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class PostRepo : BaseRepository<Post>, IPostRepo
    {
        public PostRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<Post> GetById(int Id)
        {
            return await context.Posts.Include(c => c.Category).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<Post>> GetByTitle(string postTitle)
        {
            return await context.Posts.Include(c => c.Category).Include(c => c.Staff).Where(c => c.PostTitle.StartsWith(postTitle) && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Post>> GetByCategoryId(int categoryId)
        {
            return await context.Posts.Include(c => c.Category).Include(c => c.Staff).Where(c => c.Category.Id == categoryId && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Post>> ListAllPosts()
        {
            return await context.Posts.Include(c => c.Category).Include(c => c.Staff).Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}

