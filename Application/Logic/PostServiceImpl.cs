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

    public async Task CreatePostAsync(Post post)
    {
        await _dao.CreatePostAsync(post);
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
        return _dao.GetPostByIdAsync(id);
    }

    public Task<ICollection<Post>> GetAllPosts()
    {
        return _dao.GetAllPosts();
    }
}