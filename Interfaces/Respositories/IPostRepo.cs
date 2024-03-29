﻿using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IPostRepo : IRepo<Post>
{
    Task<Post> GetById(int Id);
    Task<IList<Post>> GetByTitle(string postTitle);
    public Task<IList<Post>> GetByCategoryId(int categoryId);
    public Task<IList<Post>> ListAllPosts();
}

