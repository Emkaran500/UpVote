namespace UpVote.Models;

public class DiscussionSection
{
    public int Id { get; set; }
    
    public Discussion? Discussion { get; set; }
    public Section? Section { get; set; }
}