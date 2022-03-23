using Entities;

namespace Application.DAOs;

public interface IPostDAO
{
    public Task CreatePostAsync(Post post);
    public Task<Post> GetPostByIdAsync(int id);
    public Task<ICollection<Post>> GetAllPosts();
}