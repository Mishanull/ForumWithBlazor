using Entities;

namespace Application.DAOs;

public interface IUserDAO
{
    public Task<User?> GetUserAsync(string username);
    public Task CreateUserAsync(User user);
}