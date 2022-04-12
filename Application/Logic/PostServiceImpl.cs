using Application.DAOs;
using Contract;
using Entities;

namespace Application.Logic;

public class PostServiceImpl : IPostService
{
    private IPostDAO _dao;

    public PostServiceImpl(IPostDAO dao)
    {
        _dao = dao;
    }

    public async Task CreatePostAsync(Post? post)
    {
        if (string.IsNullOrEmpty(post.Content) || string.IsNullOrEmpty(post.Title) ||
            string.IsNullOrEmpty(post.Subtitle))
        {
            throw new Exception("All fields in the post have to be filled");
        } 
        await _dao.CreatePostAsync(post);
        
    }

    public Task<Post?> GetPostByIdAsync(int id)
    {
        return _dao.GetPostByIdAsync(id);
    }

    public Task<ICollection<Post>> GetAllPosts()
    {
        return _dao.GetAllPosts();
    }

    public async Task DeletePostAsync(int id)
    {
        await _dao.DeletePostAsync(id);
    }

    public async Task EditPostAsync(Post? post)
    {
       await _dao.EditPostAsync(post);
    }

    public async Task AddCommentToPost(Comment comment, int id)
    {
        await _dao.AddCommentToPost(comment,id);
    }

    public  Task<ICollection<Comment>> GetComments(int id)
    {
        return  _dao.GetComments(id);
    }
}