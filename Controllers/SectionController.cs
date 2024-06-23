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
    private readonly UpVoteDbContext dbContext;

    public SectionController(ISectionService sectionService, UpVoteDbContext dbContext)
    {
        this.sectionService = sectionService;
        this.dbContext = dbContext;
    }

    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var sections = await sectionService.GetAllSectionsAsync();

        return base.View(sections);
    }

    [ActionName("Get")]
    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var section = await sectionService.GetSectionByIdAsync(id);

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
