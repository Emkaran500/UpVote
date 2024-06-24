namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class DiscussionSectionService : IDiscussionSectionService
{
    private readonly IDiscussionSectionRepository discussionSectionRepository;

    public DiscussionSectionService(IDiscussionSectionRepository discussionSectionRepository)
    {
        this.discussionSectionRepository = discussionSectionRepository;
    }

    public async Task<IEnumerable<DiscussionSection>?> GetSectionFromDiscussionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(foreignName);

        var sections = await this.discussionSectionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return sections;
    }

    public async Task<IEnumerable<DiscussionSection>?> GetAllDiscussionsFromSectionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);

        var discussions = await this.discussionSectionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return discussions;
    }
}