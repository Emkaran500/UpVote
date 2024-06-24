namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class DiscussionService : IDiscussionService
{
    private readonly IDiscussionRepository discussionRepository;

    public DiscussionService(IDiscussionRepository discussionRepository)
    {
        this.discussionRepository = discussionRepository;
    }

    public async Task CreateNewDiscussionAsync(Discussion newDiscussion)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(newDiscussion.Name);

        await this.discussionRepository.CreateAsync(newDiscussion);
    }

    public async Task<IEnumerable<Discussion>?> GetAllDiscussionsAsync()
    {
        return await this.discussionRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Discussion>?> GetDiscussionByIdAsync(int? id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return await this.discussionRepository.GetByIdAsync(id.Value);
    }
}