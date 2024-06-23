namespace UpVote.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

public class DiscussionEFRepository : IDiscussionRepository
{
    private readonly UpVoteDbContext dbContext;

    public DiscussionEFRepository(UpVoteDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateAsync(Discussion? discussion)
    {
        if (discussion == null)
        {
            throw new ArgumentNullException("Discussion didn't arrive!");
        }

        await this.dbContext.Discussions.AddAsync(discussion);
        this.dbContext.SaveChanges();
    }

    public async Task<IEnumerable<Discussion>?> GetAllAsync()
    {
        var discussions = this.dbContext.Discussions.TakeWhile(discussion => true);
        return discussions;
    }

    public async Task<IEnumerable<Discussion>?> GetByIdAsync(int id)
    {
        var discussions = this.dbContext.Discussions.TakeWhile(discussion => discussion.Id == id);
        return discussions;
    }
}