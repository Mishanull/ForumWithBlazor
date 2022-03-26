namespace Entities;

public class Post
{
    public Post()
    {
        Comments = new List<Comment>();
    }

    public ICollection<Comment>? Comments { get; set; }
    public int Id { get; set; }
    public String? Title { get; set; }
    public String? Subtitle { get; set; }
    public String? Content { get; set; }
    public User? WrittenBy { get; set; }
}