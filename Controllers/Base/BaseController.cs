using System.Net;
using System.Text;

namespace UpVote.Controllers.Base;

public class BaseController
{
    public HttpListenerResponse? Response { get; set; }

    protected async Task LayoutAsync(string contentHtml, string layoutName = "nothing")
    {
        Response.ContentType = "text/html";
        using var streamWriter = new StreamWriter(Response.OutputStream);

        var indexHtml = await File.ReadAllTextAsync("./Views/index.html");

        var firstPart = indexHtml.Split("<main>").FirstOrDefault();
        var lastPart = indexHtml.Split("</main>").LastOrDefault();

        var bodyHtml = firstPart + "<main></main>" + lastPart;
        bodyHtml = bodyHtml.Replace("<main></main>", contentHtml);

        await streamWriter.WriteLineAsync(bodyHtml);
    }

    protected async Task WriteViewAsync(IEnumerable<object>? viewValues = null, string? layoutName = null)
    {
        var htmlSb = new StringBuilder();
        htmlSb.Append(await File.ReadAllTextAsync($"./Views/{layoutName}.html"));
        var contentIndex = 6;

        if (viewValues is not null)
        {
            foreach (var viewValue in viewValues)
            {
                htmlSb.Insert(contentIndex, viewValue.ToString());
            }
        }

        await LayoutAsync(htmlSb.ToString(), layoutName ?? "nothing");
    }
}