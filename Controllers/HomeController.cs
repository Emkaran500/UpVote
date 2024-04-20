namespace UpVote.Controllers;

using UpVote.Controllers.Base;
using UpVote.HttpAttributes;

public class HomeController : BaseController
{
    [HttpGet]
    public async Task Index() {
        await WriteViewAsync(new object(), null, "index");
    }
}