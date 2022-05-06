namespace Entities;

public class Forum
{
    public ICollection<Post?>? Posts { get; set; }
    
   public ICollection<User?>? Users { get; set; }
    public Forum()
    {
        Posts = new List<Post>();
    }
}