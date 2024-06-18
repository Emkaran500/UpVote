namespace UpVote.Controllers;

using System.Reflection;
using UpVote.Controllers.Base;
using UpVote.HttpAttributes;

public class StylesController : BaseController
{
    private async Task StylesAsync(string styleName)
    {
        string? folder = "/";
        if (styleName.Contains(".css"))
        {
            Response.ContentType = "text/css";
        }
        else if (styleName.Contains(".ttf"))
        {
            Response.ContentType = "text/plain";
            folder = "/Fonts/";
        }
        using var streamWriter = new StreamWriter(Response.OutputStream);

        var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../Styles{folder}{styleName}");
        var styleText = await File.ReadAllTextAsync(path);
        await streamWriter.WriteLineAsync(styleText);
    }

    [HttpGet]
    public async Task GetStyle(string endpoint) {
        await StylesAsync(endpoint);
    }
}