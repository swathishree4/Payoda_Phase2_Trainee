using Microsoft.EntityFrameworkCore;
using MVC_MAINTEST.Models;
using MVC_MAINTEST.Repository;

namespace MVC_MAINTEST.Service
{
    public class Postservice:IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public Postservice(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(p => p.User).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int uId)
        {
            return await _context.Posts.Where(p => p.UserId == uId).ToListAsync();
        }

    }
}
