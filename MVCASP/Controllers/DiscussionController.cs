using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UpVote.Models;
using UpVote.Models;

namespace UpVote.Controllers;

public class DiscussionController : Controller
{
    [Route("[controller]")]
    public async Task<IActionResult> Index()
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");

        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);

        return base.View(discussions);
    }

    [ActionName("Get")]
    [Route("[controller]/[action]/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");
        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);
        var searchedDiscussion = discussions?.FirstOrDefault((discussion) => discussion?.Name == name, null);
        IEnumerable<Discussion> searchedDiscussionAsEnumerable = new Discussion[] {searchedDiscussion};

        return base.View("Index", searchedDiscussionAsEnumerable);
    }
}
