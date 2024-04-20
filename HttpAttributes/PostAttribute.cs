namespace UpVote.HttpAttributes;

using UpVote.HttpAttributes.Base;

public class HttpPostAttribute : BaseAttribute
{
    public HttpPostAttribute() : base("POST") {}
}