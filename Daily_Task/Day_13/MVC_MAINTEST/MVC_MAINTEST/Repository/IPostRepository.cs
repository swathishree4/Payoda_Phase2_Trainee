using MVC_MAINTEST.Models;

namespace MVC_MAINTEST.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(int uId);
    }
}
