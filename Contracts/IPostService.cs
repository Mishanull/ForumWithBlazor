using System.Globalization;
using Entities;

namespace Contract;

public interface IPostService
{
    public Task CreatePostAsync(Post? post);
    public Task<Post?> GetPostByIdAsync(int id);
    public Task<ICollection<Post>> GetAllPosts();
    public Task DeletePostAsync(int id);
    public Task EditPostAsync(Post? post);
    public Task AddCommentToPost(Comment comment, int id);
    public Task<ICollection<Comment>> GetComments(int id);
}