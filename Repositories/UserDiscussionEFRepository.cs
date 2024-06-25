using System.Collections;
using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class UserDiscussionEFRepository : IUserDiscussionRepository<IEnumerable>
{
    private readonly UpVoteDbContext dbContext;

    public UserDiscussionEFRepository(UpVoteDbContext context)
    {
        this.dbContext = context;
    }
    public async Task<IEnumerable> GetByForeignIdAsync(int id, string foreignName)
    {
        IEnumerable<UserDiscussion> userDiscussion;
        if (foreignName == "User")
        {
            userDiscussion = this.dbContext.UsersDiscussions.AsEnumerable().Where(userDiscussion => userDiscussion.User.Id == id);
            List<User> users = new List<User>();
            foreach (var user in userDiscussion)
            {
                users.Add(this.dbContext.Users.First(oldUser => oldUser.Id == user.Id));
            }
            return users.AsEnumerable();
        }
        else if (foreignName == "Discussion")
        {
            userDiscussion = this.dbContext.UsersDiscussions.AsEnumerable().Where(userDiscussion => userDiscussion.Discussion.Id == id);
            List<Discussion> discussions = new List<Discussion>();
            foreach (var discussion in userDiscussion)
            {
                discussions.Add(this.dbContext.Discussions.First(oldDiscussion => oldDiscussion.Id == discussion.Id));
            }
            return discussions.AsEnumerable();
        }
        else
        {
            throw new Exception($"{foreignName} is incorrect!");
        }
    }
}