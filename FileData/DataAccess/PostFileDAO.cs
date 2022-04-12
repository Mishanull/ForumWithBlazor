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

    public async Task CreatePostAsync(Post? post)
    {
        if (_context.Forum.Posts != null && _context.Forum.Posts.Any())
        {
            var largestId = _context.Forum.Posts.Max(p => p.Id);
            post.Id = largestId + 1;
        }
        else
        {
            post.Id = 1;
        }
        _context.Forum.Posts?.Add(post);
        await _context.SaveChangesAsync();
    }

    public Task<Post?> GetPostByIdAsync(int id)
    {
       return Task.FromResult(_context.Forum.Posts.First(post => post.Id == id));
    }

    public Task<ICollection<Post>> GetAllPosts()
    {
        return Task.FromResult(_context.Forum.Posts);
    }

    public  async Task DeletePostAsync(int id)
    {
         _context.Forum.Posts?.Remove(_context.Forum.Posts.First((post => post.Id == id)));
         await _context.SaveChangesAsync();
    }

    public async Task EditPostAsync(Post? post)
    {
        Post? p = _context.Forum.Posts.First(p => post.Id == p.Id);
        p.Content = post.Content;
        p.Title = post.Title;
        p.Subtitle = post.Subtitle;
        await _context.SaveChangesAsync();
    }

    public async Task AddCommentToPost(Comment comment, int id)
    {
        Post? p = _context.Forum.Posts.First(p => id == p.Id);
        p.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public Task<ICollection<Comment>> GetComments(int id)
    {
        Post? p = _context.Forum.Posts.First(p => id == p.Id);
        return  Task.FromResult(p.Comments!);
    }
}