using UpVote.Models;

namespace UpVote.Services.Base
{
    public interface IUserDiscussionService
    {
        public Task<IEnumerable<UserDiscussion>?> GetAllUsersFromDiscussionAsync(int? id, string? foreignName);
        public Task<IEnumerable<UserDiscussion>?> GetAllDiscussionsFromUserAsync(int? id, string? foreignName);
    }
}