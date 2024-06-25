namespace UpVote.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Models;
using UpVote.Repositories.Base;
using UpVote.Services.Base;

public class UserDiscussionService<T> : IUserDiscussionService
{
    private readonly IUserDiscussionRepository<T> userDiscussionRepository;

    public UserDiscussionService(IUserDiscussionRepository<T> userDiscussionRepository)
    {
        this.userDiscussionRepository = userDiscussionRepository;
    }

    public async Task<IEnumerable<User>?> GetAllUsersFromDiscussionAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(foreignName);

        var users = await this.userDiscussionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return (IEnumerable<User>?)users;
    }

    public async Task<IEnumerable<Discussion>?> GetAllDiscussionsFromUserAsync(int? id, string? foreignName)
    {
        ArgumentNullException.ThrowIfNull(id);

        var discussions = await this.userDiscussionRepository.GetByForeignIdAsync(id.Value, foreignName);
        return (IEnumerable<Discussion>?)discussions;
    }
}