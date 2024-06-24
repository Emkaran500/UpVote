using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class UserDiscussionEFRepository : IUserDiscussionRepository
{
    private readonly UpVoteDbContext dbContext;

    public UserDiscussionEFRepository(UpVoteDbContext context)
    {
        this.dbContext = context;
    }
    public async Task<IEnumerable<UserDiscussion>?> GetByForeignIdAsync(int id, string foreignName)
    {
        IEnumerable<UserDiscussion> userDiscussion;
        if (foreignName == "User")
        {
            userDiscussion = this.dbContext.UsersDiscussions.AsEnumerable().Where(userDiscussion => userDiscussion.User.Id == id);
        }
        else if (foreignName == "Discussion")
        {
            userDiscussion = this.dbContext.UsersDiscussions.AsEnumerable().Where(userDiscussion => userDiscussion.Discussion.Id == id);
        }
        else
        {
            throw new Exception($"{foreignName} is incorrect!");
        }

        return userDiscussion;
    }
}