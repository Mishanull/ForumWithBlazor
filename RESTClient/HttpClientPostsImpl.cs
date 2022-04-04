using Contract;
using Entities;

namespace RESTClient;

public class HttpClientPostsImpl : IPostService
{
    public Task CreatePostAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Post>> GetAllPosts()
    {
        throw new NotImplementedException();
    }

    public Task DeletePostAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task EditPostAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task AddCommentToPost(Comment comment, int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Comment>> GetComments(int id)
    {
        throw new NotImplementedException();
    }
}