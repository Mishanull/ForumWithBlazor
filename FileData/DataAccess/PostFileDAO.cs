using Application.DAOs;
using Entities;

namespace FileData.DataAccess;

public class PostFileDAO : IPostDAO
{
    private PostFileContext _context;

    public PostFileDAO(PostFileContext context)
    {
        _context = context;
    }

    public async Task CreatePostAsync(Post post)
    {
        var largestId = _context.Forum.Posts.Max(p => p.Id);
        post.Id = largestId + 1;
        _context.Forum.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
       return Task.FromResult(_context.Forum.Posts.First(post => post.Id == id));
    }

    public Task<ICollection<Post>> GetAllPosts()
    {
        return Task.FromResult(_context.Forum.Posts);
    }
}