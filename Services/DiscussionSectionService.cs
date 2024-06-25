namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class DiscussionSectionService<T> : IDiscussionSectionService
{
    private readonly IDiscussionSectionRepository<T> discussionSectionRepository;

    public DiscussionSectionService(IDiscussionSectionRepository<T> discussionSectionRepository)
    {
        this.discussionSectionRepository = discussionSectionRepository;
    }

    public async Task<IEnumerable<Section>?> GetSectionFromDiscussionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(foreignName);

        var sections = await this.discussionSectionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return (IEnumerable<Section>?)sections;
    }

    public async Task<IEnumerable<Discussion>?> GetAllDiscussionsFromSectionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);

        var discussions = await this.discussionSectionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return (IEnumerable<Discussion>?)discussions;
    }
}