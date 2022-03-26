namespace Entities;

public class Forum
{
    public ICollection<Post>? Posts { get; set; }
    public ICollection<SubForum>? SubForums { get; set; }
    public Forum()
    {
        SubForums = new List<SubForum>();
        Posts = new List<Post>();
    }
}