using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class UserEFRepository : IUserRepository
{
    private readonly UpVoteDbContext dbContext;
    public async Task<IEnumerable<User>?> GetByIdAsync(int id)
    {
        var users = this.dbContext.Users.TakeWhile(user => user.Id == id);
        return users;
    }
}