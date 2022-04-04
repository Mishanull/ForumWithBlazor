using Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController: ControllerBase
{
    private IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> GetAllPosts()
    {
        try
        {
            ICollection<Post> posts = await _postService.GetAllPosts();
            return Ok(posts);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        try
        {
             await _postService.CreatePostAsync(post);
            return Created($"/posts/{post.Id}",post);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Post>> GetPost([FromRoute] int id)
    {
        try
        {
            Post p= await _postService.GetPostByIdAsync(id);
            return Ok(p);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPatch]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> UpdatePost([FromBody] Post post)
    {
        try
        {
             await _postService.EditPostAsync(post);
            return Ok("Post "+post.Id+" successfully updated");

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}