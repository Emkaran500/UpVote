using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IDiscussionService
    {
        public Task CreateNewDiscussionAsync(Discussion newDiscussion);
        public Task<IEnumerable<Discussion>?> GetAllDiscussionsAsync();
        public Task<IEnumerable<Discussion>?> GetDiscussionByIdAsync(int? id);
    }
}