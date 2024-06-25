using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

namespace UpVote.Controllers;

public class SectionController : Controller
{
    private readonly ISectionService sectionService;
    private readonly IDiscussionSectionService discussionSectionService;

    public SectionController(ISectionService sectionService, IDiscussionSectionService discussionSectionService)
    {
        this.sectionService = sectionService;
        this.discussionSectionService = discussionSectionService;
    }

    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var sections = await sectionService.GetAllSectionsAsync();
        base.ViewBag.Discussions = null;
        base.ViewBag.Count = sections.Count();

        return base.View(sections);
    }

    [ActionName("Get")]
    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var section = await sectionService.GetSectionByIdAsync(id);
        var discussions = await this.discussionSectionService.GetAllDiscussionsFromSectionAsync(id, nameof(Discussion));
        base.ViewBag.Discussions = discussions is not null && discussions.Any() ? discussions : null;
        base.ViewBag.Count = section.Count();

        return base.View("Index", section);
    }

    [HttpGet("[action]", Name = "CreateSection")]
    public IActionResult Create()
    {
        return base.View();
    }

    [HttpPost("api/[controller]/[action]")]
    public async Task<IActionResult> Create(Section? newSection)
    {
        await sectionService.CreateNewSectionAsync(newSection);

        return base.RedirectToAction("Index");
    }

    [HttpGet("[action]/{id}", Name = "UpdateSection")]
    public async Task<IActionResult> Update(int id)
    {
        var section = (await this.sectionService.GetSectionByIdAsync(id)).FirstOrDefault();

        return base.View(section);
    }

    [HttpGet("api/[controller]/[action]")]
    public async Task<IActionResult> Update(Section? section)
    {
        await sectionService.UpdateSectionAsync(section);

        return base.RedirectToAction("Get", new {section?.Id});
    }

    [HttpGet("[action]/{id}", Name = "DeleteSection")]
    public async Task<IActionResult> Delete(int id)
    {
        var section = (await this.sectionService.GetSectionByIdAsync(id)).FirstOrDefault();

        return base.View(section);
    }

    [HttpGet("api/[controller]/[action]/{id}")]
    public async Task<IActionResult> Delete(int? id)
    {
        await sectionService.DeleteSectionAsync(id);

        return base.RedirectToAction("Index");
    }
}
