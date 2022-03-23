using Entities;

namespace Contract;

public interface IUserService
{
    public  Task<User?> GetUserAsync(string username);
    public Task CreateUserAsync(User user);
}