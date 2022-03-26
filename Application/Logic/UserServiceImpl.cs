using Application.DAOs;
using Contract;
using Entities;

namespace Application.Logic;

public class UserServiceImpl : IUserService
{
    private readonly IUserDAO _userDao;

    public UserServiceImpl(IUserDAO userDao)
    {
        _userDao = userDao;
    }

    public Task<User?> GetUserAsync(string username)
    {
        return _userDao.GetUserAsync(username);
    }

    public async Task CreateUserAsync(User user)
    {
        await _userDao.CreateUserAsync(user);
    }
}