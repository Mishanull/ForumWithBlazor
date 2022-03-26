namespace Entities;

public class SubForum
{
    private string Name { get; set; }
    public ICollection<Post>? Posts { get; set; }
    
    public SubForum() {
        Posts = new List<Post>();
    }
}