using Application.DAOs;
using Entities;

namespace FileData.DataAccess;

public class UserFileDAO : IUserDAO
{
    private UserFileContext fileContext;

    public UserFileDAO(UserFileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<User?> GetUserAsync(string username)
    {
        User? u=  fileContext.Users.First(u => u.UserName.Equals(username));
        return u;
    }

    public async Task CreateUserAsync(User user)
    {
        if (fileContext.Users.Contains(user))
        {
            throw new Exception("Username taken, please use another. ");
        }
        fileContext.Users.Add(user);
        fileContext.SaveChanges();
    }
}