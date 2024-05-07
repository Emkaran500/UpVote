namespace UpVote.Services;

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
}