using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

namespace UpVote.Controllers;

public class DiscussionController : Controller
{
    private readonly IDiscussionService discussionService;
    private readonly IUserDiscussionService userDiscussionService;

    public DiscussionController(IDiscussionService discussionService, IUserDiscussionService userDiscussionService)
    {
        this.discussionService = discussionService;
        this.userDiscussionService = userDiscussionService;
    }

    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var discussion = await discussionService.GetAllDiscussionsAsync();

        return base.View(discussion);
    }

    [ActionName("Get")]
    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var discussion = await discussionService.GetDiscussionByIdAsync(id);
        base.ViewBag.Users = await this.userDiscussionService.GetAllUsersFromDiscussionAsync(id, nameof(Discussion));

        return base.View("Index", discussion);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return base.View();
    }

    [HttpPost("[controller]/[action]")]
    public async Task<IActionResult> Create(Discussion newDiscussion)
    {
        await discussionService.CreateNewDiscussionAsync(newDiscussion);

        return base.RedirectToAction("Index");
    }
}
