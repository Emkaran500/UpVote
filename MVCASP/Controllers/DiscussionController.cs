using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UpVote.Models;

namespace UpVote.Controllers;

public class DiscussionController : Controller
{
    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> Index()
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");

        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);

        return base.View(discussions);
    }

    [HttpGet]
    [ActionName("Get")]
    [Route("[controller]/[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");
        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);
        var searchedDiscussion = discussions?.FirstOrDefault((discussion) => discussion?.Id == id, null);
        IEnumerable<Discussion> searchedDiscussionAsEnumerable = new Discussion[] {searchedDiscussion};

        return base.View("Index", searchedDiscussionAsEnumerable);
    }

    [HttpGet]
    [ActionName("CreationPage")]
    [Route("[controller]/[action]")]
    public IActionResult Create()
    {
        return base.View("Create");
    }

    [HttpPost]
    [ActionName("Create")]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> CreateNewDiscussion(Discussion newDiscussion)
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");

        var discussions = JsonSerializer.Deserialize<List<Discussion>>(discussionsJson, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
        });

        var maxId = discussions.Max(discussion => discussion.Id);
        newDiscussion.Id = maxId + 1;

        discussions?.Add(newDiscussion);

        var newDiscussionsJson = JsonSerializer.Serialize<List<Discussion>>(discussions, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
        });

        await System.IO.File.WriteAllTextAsync("Assets/discussions.json", newDiscussionsJson);

        return base.RedirectToAction(actionName: "Index");
    }
}
