namespace UpVote.HttpAttributes;

using UpVote.HttpAttributes.Base;

public class HttpGetAttribute : BaseAttribute
{
    public HttpGetAttribute() : base("GET") {}
}