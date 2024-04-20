using System.Net;
using System.Reflection;
using System.Text;

namespace UpVote.Controllers.Base;

public class BaseController
{
    public HttpListenerResponse? Response { get; set; }
    public HttpListenerRequest? Request { get; set; }

    protected async Task LayoutAsync(string contentHtml, string layoutName = "index")
    {
        Response.ContentType = "text/html";
        using var streamWriter = new StreamWriter(Response.OutputStream);

        var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../Views/{layoutName}.html");
        var indexHtml = await File.ReadAllTextAsync(path);

        var firstPart = indexHtml.Split("<main>").FirstOrDefault();
        var lastPart = indexHtml.Split("</main>").LastOrDefault();

        var bodyHtml = firstPart + "<main></main>" + lastPart;
        bodyHtml = bodyHtml.Replace("<main></main>", contentHtml);

        await streamWriter.WriteLineAsync(bodyHtml);
    }

    protected async Task WriteViewAsync<T>(T? instance, Dictionary<string, object>? viewValues = null, string? layoutName = null, string? contentsName = null)
    {
        var htmlSb = new StringBuilder();
        var contentsSb = new StringBuilder();
        try
        {
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../Views/{contentsName}.html");
            htmlSb.Append(await File.ReadAllTextAsync(path));
        }
        catch
        {
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "../../../Views/nothing.html");
            htmlSb.Append(await File.ReadAllTextAsync(path));
        }

        Type itemType = typeof(T);
        var properties = itemType.GetProperties();

        if (viewValues is not null)
        {
            foreach (var viewValue in viewValues)
            {
                contentsSb.Append("<div>");
                foreach (var itemPropertyInfo in properties)
                {
                    if (itemPropertyInfo.Name == "Id" || itemPropertyInfo.Name == "Password")
                        continue;

                    contentsSb.Append($"<label>{itemPropertyInfo.Name}:</label> <input type=\"text\" readonly value=\"{itemPropertyInfo.GetValue(viewValue.Value)}\"></input>");
                }
                contentsSb.Append("</div>");
            }
            htmlSb = htmlSb.Replace("{{" + contentsName + "}}", contentsSb.ToString());
        }

        await LayoutAsync(htmlSb.ToString(), layoutName ?? "index");
    }
}