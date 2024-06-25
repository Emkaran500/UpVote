using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IUserDiscussionService
    {
        public Task<IEnumerable<User>?> GetAllUsersFromDiscussionAsync(int? id, string? foreignName);
        public Task<IEnumerable<Discussion>?> GetAllDiscussionsFromUserAsync(int? id, string? foreignName);
    }
}