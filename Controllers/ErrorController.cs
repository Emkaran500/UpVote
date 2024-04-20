namespace UpVote.Controllers;

using System.Net;
using UpVote.HttpAttributes;
using UpVote.Controllers.Base;

public class ErrorController : BaseController
{
    [HttpGet]
    public async Task NotFound(string? resourceName) {
        Dictionary<string, object>? viewValues = new() {
            {"resource", resourceName ?? "/"}
        };

        await WriteViewAsync(new object(), viewValues, "index", "notfound");

        base.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }
}