namespace UpVote.Models;

public class Section
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public DateTime? CreationDate { get; set;}
    public List<Discussion>? Discussions { get; set;} = new List<Discussion>();
}