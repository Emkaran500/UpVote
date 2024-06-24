using UpVote.Data;
using UpVote.Models;
using UpVote.Repositories.Base;

namespace UpVote.Repositories;

public class DiscussionSectionEFRepository : IDiscussionSectionRepository
{
    private readonly UpVoteDbContext dbContext;

    public DiscussionSectionEFRepository(UpVoteDbContext context)
    {
        this.dbContext = context;
    }
    public async Task<IEnumerable<DiscussionSection>?> GetByForeignIdAsync(int id, string foreignName)
    {
        IEnumerable<DiscussionSection> discussionSection;
        if (foreignName == "Discussion")
        {
            discussionSection = this.dbContext.DiscussionsSections.AsEnumerable().Where(discussionSection => discussionSection.Discussion.Id == id);
        }
        else if (foreignName == "Discussion")
        {
            discussionSection = this.dbContext.DiscussionsSections.AsEnumerable().Where(discussionSection => discussionSection.Section.Id == id);
        }
        else
        {
            throw new Exception($"{foreignName} is incorrect!");
        }

        return discussionSection;
    }
}