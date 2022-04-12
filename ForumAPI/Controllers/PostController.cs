using System.Collections;
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
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post? post)
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
            Post? p= await _postService.GetPostByIdAsync(id);
            return Ok(p);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPatch]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> UpdatePost([FromBody] Post? post)
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

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> DeletePost([FromRoute] int id)
    {
        try
        {
            await _postService.DeletePostAsync(id);
            return Ok("Post " + id + " succesfully deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPost]
    [Route("{id:int}/comments")]
    public async Task<ActionResult<Comment>> CreateComment([FromRoute] int id, [FromBody] Comment comment)
    {
        try
        {
            await _postService.AddCommentToPost(comment,id);
            return Created($"/id/comments",comment);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    [Route("{id:int}/comments")]
    public async Task<ActionResult<ICollection<Comment>>> GetComments([FromRoute] int id)
    {
        try
        {
            ICollection<Comment> comments=await _postService.GetComments(id);
            return Ok(comments);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}