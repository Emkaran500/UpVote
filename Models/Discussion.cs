using Upvote.Models;

namespace UpVote.Models;

public class Discussion
{
    public string? Name { get; set;}
    public ICollection<User> Users { get; set;}
}