using Contract;
using Entities;

namespace RESTClient;

public class HttpClientUsersImpl : IUserService
{
    public Task<User?> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}