using Entities;

namespace Contract;

public interface IPostService
{
    public Task CreatePostAsync(Post post);
    public Task<Post> GetPostByIdAsync(int id);
    public Task<ICollection<Post>> GetAllPosts();
}