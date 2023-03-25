using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IPostRepo : IRepo<Post>
    {
        Task<Post> GetById(int Id);
        Task<IList<Post>> GetByTitle(string postTitle);
        public Task<IList<Post>> GetByCategoryId(int categoryId);
        public Task<IList<Post>> ListAllPosts();
    }
}

