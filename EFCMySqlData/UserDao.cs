using Application.DAOs;
using Contract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCPostgresData;

public class UserDao : IUserDAO
{
    private ForumContext context;

    public UserDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User?> GetUserAsync(string username)
    {
        User? u = await context.User.FirstAsync(user =>user.UserName==username );
        return u;
    }

    public async Task CreateUserAsync(User user)
    {
        await context.User.AddAsync(user);
        await context.SaveChangesAsync();
    }
}