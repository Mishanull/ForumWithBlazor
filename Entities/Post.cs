namespace Entities;

public class Post
{
    public int Id { get; set; }
    public String Title { get; set; }
    public String Subtitle { get; set; }
    public String Content { get; set; }
    public User? WrittenBy { get; set; }
}