namespace UpVote.Controllers;

using UpVote.Controllers.Base;

public class HomeController : BaseController
{
    public async Task Index() {
        await WriteViewAsync(null, "index");
    }
}