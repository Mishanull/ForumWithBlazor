using Entities;

namespace Contract;
//TODO Methods for SubForum
public interface ISubService
{
    public Task<ICollection<Post>> GetPostsInSub(string name);
}