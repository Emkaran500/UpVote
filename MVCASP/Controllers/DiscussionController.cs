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
    private readonly IDiscussionRepository discussionRepository;

    public DiscussionController(IDiscussionService productService, IDiscussionRepository productRepository)
    {
        this.discussionRepository = productRepository;
        this.discussionService = productService;
    }

    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var discussion = await discussionRepository.GetAllAsync();

        return base.View(discussion);
    }

    [ActionName("Get")]
    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var discussion = await discussionRepository.GetByIdAsync(id);

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
