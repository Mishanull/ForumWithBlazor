using Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<User>> GetUser([FromRoute] string username)
    {
        try
        {
            User u = await _userService.GetUserAsync(username);
            return Ok(u);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User u)
    {
        try
        {
            await _userService.CreateUserAsync(u);
            return Created($"/users/{u.UserName}",u);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}