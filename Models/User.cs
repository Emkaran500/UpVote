namespace Upvote.Models;

public class User
{
    public int Id { get; set; }
    public string? Nickname { get; set;}
    public string? Password { get; set;}
    public DateTime? CreationDate { get; set;}

    public override string ToString()
    {
        return this.Nickname;
    }
}