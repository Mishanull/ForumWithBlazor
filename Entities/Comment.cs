namespace Entities;

public class Comment
{
    
    public long Id { get; set; }
    public String? Content { get; set; }
    public User? WrittenBy { get; set; }
}