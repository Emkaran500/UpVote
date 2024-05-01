using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MVCASP.Models;
using UpVote.Models;

namespace MVCASP.Controllers;

public class DiscussionController : Controller
{
    [Route("[controller]")]
    public async Task<IActionResult> Index()
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");

        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);

        return base.Ok(discussions);
    }

    [Route("[controller]/[action]/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var discussionsJson = await System.IO.File.ReadAllTextAsync("Assets/discussions.json");

        var discussions = JsonSerializer.Deserialize<IEnumerable<Discussion>>(discussionsJson);

        var searchedDiscussion = discussions?.FirstOrDefault((discussion) => discussion?.Name == name, null);

        return Ok(searchedDiscussion);
    }
}
