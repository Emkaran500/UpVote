namespace UpVote.HttpAttributes.Base;

[AttributeUsage(AttributeTargets.Method)]
public class BaseAttribute : Attribute
{
    public readonly string MethodType;
    public string ActionName = "";

    public BaseAttribute(string methodType)
    {
        this.MethodType = methodType;
    }
}