namespace UpVote.HttpAttributes;

using UpVote.HttpAttributes.Base;

public class HttpDeleteAttribute : BaseAttribute
{
    public HttpDeleteAttribute() : base("DELETE") {}
}