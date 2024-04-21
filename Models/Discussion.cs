using Upvote.Models;

namespace UpVote.Models;

public class Discussion
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public List<User>? Users { get; set;} = new List<User>();

    public override string ToString()
    {
        return this.Name;
    }
}