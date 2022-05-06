using Application.DAOs;
using Contract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCPostgresData;

public class PostDao : IPostDAO
{
    private ForumContext _context;

    public PostDao(ForumContext context)
    {
        _context = context;
    }

    public async Task CreatePostAsync(Post? post)
    {
        try
        {
             _context.User.Attach(post.WrittenBy);
            await _context.Post.AddAsync(post!);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.InnerException);
        }
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        Post? newPost = await _context.Post.FindAsync(id);
        return newPost;
    }

    public async Task<ICollection<Post>> GetAllPosts()
    {
        ICollection<Post> posts = await _context.Post.ToListAsync();
        return posts;
    }

    public async Task DeletePostAsync(int id)
    {
        Post? p = await _context.Post.FindAsync(id);
        if (p is null)
        {
            throw new Exception($"Could not find post with id {id}. Delete operation cancelled.");
        }

        _context.Post.Remove(p);
        await _context.SaveChangesAsync();
    }

    public async Task EditPostAsync(Post? post)
    {
         _context.Post.Update(post);
         await _context.SaveChangesAsync();
    }

    public async Task AddCommentToPost(Comment comment, int id)
    
    {
        Post? p = await _context.Post.FindAsync(id);
        if (p is null)
        {
            throw new Exception($"Could not find post with id {id}. Adding comment operation failed.");
        }

        _context.User.Attach(comment.WrittenBy);
        p?.Comments?.Add(comment);
        _context.Post.Update(p!);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Comment>> GetComments(int id)
    {
        Post? p = await _context.Post.FindAsync(id);
        if (p is null)
        {
            throw new Exception($"Could not find post with id {id}, retrieving comments impossible.");
        }

        return p.Comments!;
    }
}