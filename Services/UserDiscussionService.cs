namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class UserDiscussionService : IUserDiscussionService
{
    private readonly IUserDiscussionRepository userDiscussionRepository;

    public UserDiscussionService(IUserDiscussionRepository userDiscussionRepository)
    {
        this.userDiscussionRepository = userDiscussionRepository;
    }

    public async Task<IEnumerable<UserDiscussion>?> GetAllUsersFromDiscussionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(foreignName);

        var users = await this.userDiscussionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return users;
    }

    public async Task<IEnumerable<UserDiscussion>?> GetAllDiscussionsFromUserAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);

        var users = await this.userDiscussionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return users;
    }
}