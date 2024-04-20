namespace UpVote.HttpAttributes;

using UpVote.HttpAttributes.Base;

public class HttpDeleteAttribute : HttpAttribute
{
    public HttpDeleteAttribute() : base("DELETE") {}
}