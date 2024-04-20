namespace UpVote.HttpAttributes;

using UpVote.HttpAttributes.Base;

public class HttpGetAttribute : HttpAttribute
{
    public HttpGetAttribute() : base("GET") {}
}