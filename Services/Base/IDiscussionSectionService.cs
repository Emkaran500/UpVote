using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IDiscussionSectionService
    {
        public Task<IEnumerable<Discussion>?> GetAllDiscussionsFromSectionAsync(int? id, string? foreignName);
        public Task<IEnumerable<Section>?> GetSectionFromDiscussionAsync(int? id, string? foreignName);
    }
}