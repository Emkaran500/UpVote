using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IDiscussionService
    {
        public Task CreateNewDiscussionAsync(Discussion newDiscussion);
    }
}