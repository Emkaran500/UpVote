using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IDiscussionSectionService
    {
        public Task<IEnumerable<DiscussionSection>?> GetAllDiscussionsFromSectionAsync(int? id, string? foreignName);
        public Task<IEnumerable<DiscussionSection>?> GetSectionFromDiscussionAsync(int? id, string? foreignName);
    }
}