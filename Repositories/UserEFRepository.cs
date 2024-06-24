using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class UserEFRepository : IUserRepository
{
    private readonly UpVoteDbContext dbContext;

    public UserEFRepository(UpVoteDbContext context)
    {
        this.dbContext = context;
    }

    public async Task<IEnumerable<User>?> GetByIdAsync(int id)
    {
        var users = this.dbContext.Users.AsEnumerable().Take(new Range(id - 1, id));
        return users;
    }
}