using CatsTagram.Models;
using Microsoft.EntityFrameworkCore;

namespace CatsTagram.Data.Services
{
    public class PostsService : IpostsService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public PostsService(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void Add(Post post)
        {
            _context.CatPosts.Add(post);
            _context.SaveChanges();
        }

        public Task AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var result = await _context.CatPosts.ToListAsync();
            return result;
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(int id, Post newPost)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> UpdateAsync(int id, Post newPost)
        {
            _context.Update ( newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }
    }
}
