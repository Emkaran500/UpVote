namespace UpVote.Models;

public class UserDiscussion
{
    public int Id { get; set; }
    
    public User? User { get; set; }
    public Discussion? Discussion { get; set; }
}