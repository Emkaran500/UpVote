using Upvote.Models;

namespace UpVote.Models;

public class Discussion
{
    public int? Id { get; set; }
    public string? Name { get; set;}
    public ICollection<User>? Users { get; set;}
}