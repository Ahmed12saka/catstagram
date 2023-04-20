using CatsTagram.Models;

namespace CatsTagram.Data.Services
{
    public interface IpostsService
    {
        Task<IEnumerable<Post>> GetAll();
        Post GetById(int id);
        void Add(Post post);
        Task< Post> Update(int id, Post newPost);
        void Delete(int id);
        Task AddPost(Post post);

        Task EditPost(Post post);

        Task DeletePost(int id);
    }
}
