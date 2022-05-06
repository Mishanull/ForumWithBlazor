using Application.DAOs;
using Entities;

namespace FileData.DataAccess;

public class UserFileDAO : IUserDAO
{
    private ForumFileContext fileContext;

    public UserFileDAO(ForumFileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<User?> GetUserAsync(string username)
    {
        User? u=  fileContext.Forum.Users!.First(u => u.UserName.Equals(username));
        return u;
    }

    public async Task CreateUserAsync(User user)
    {
        if (fileContext.Forum.Users!.Contains(user))
        {
            throw new Exception("Username taken, please use another. ");
        }
        fileContext.Forum.Users.Add(user);
        await fileContext.SaveChangesAsync();
    }
}